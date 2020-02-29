using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LG_Dashboard.Data;
using LG_Dashboard.Models;
namespace LG_Dashboard.Controllers
{
    public class APIDataController : Controller
    {

        private DateTime StartDate;
        private DateTime EndDate;
        private int RetailerID;

        private LGConfigurator2019Entities db = new LGConfigurator2019Entities();
        private LGConfigurator2019_trackingEntities dbtracking = new LGConfigurator2019_trackingEntities();

        public JsonResult Refresh(string startDate, string endDate, int retailerid)
        {
            #region Assign Private Var
            StartDate = Convert.ToDateTime(startDate);
            EndDate = Convert.ToDateTime(endDate);
            RetailerID = retailerid;
            #endregion

            List<LG_Dashboard.Data.Session> Sessions = GetSession();

            int TotalPDFEmailCount = 0;
            DashboardViewModel viewModel = new DashboardViewModel()
            {
                SessionCount = Sessions.Count(),
                TopProductCategories = TopProductCategories(ref Sessions,ref TotalPDFEmailCount),
                TotalPDFEmailCount = TotalPDFEmailCount,
                SessionDreamConfiguration = SessionDreamConfiguration(Sessions),
                TopProductModels = TopProductModels(Sessions)
            };

           return new JsonResult() { Data = viewModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        private List<LG_Dashboard.Data.Session> GetSession()
        {
            if (RetailerID == 0)
            {
                return dbtracking.Sessions.Where(x => x.StartTimestamp >= StartDate && x.StartTimestamp <= EndDate).ToList();
            }
            else
            {
                return dbtracking.Sessions.Where(x => x.StartTimestamp >= StartDate && x.StartTimestamp <= EndDate && x.RetailerId == RetailerID).ToList();
            }
        }

        private List<TopProductCategory> TopProductCategories(ref List<LG_Dashboard.Data.Session> Sessions, ref int TotalPDFEmailCount)
        {
            try
            {
                var queryString = $"SELECT * FROM LGConfigurator2019_tracking.dbo.Session session INNER JOIN LGConfigurator2019_tracking.dbo.TrackingProduct tracking ON session.SessionId = tracking.SessionId INNER JOIN LGConfigurator2019.dbo.Product product ON tracking.ModelNumber = product.ModelNumber;";
                var result = dbtracking.Sessions.SqlQuery(queryString).Where(x => x.StartTimestamp >= StartDate && x.StartTimestamp <= EndDate && x.RetailerId == RetailerID).ToList();
            }
            catch(Exception ex)
            {

            }

            List<TopProductCategory> TopProductCategoryList = new List<TopProductCategory>();
            List<TrackingObject> TrackingObjectList = new List<TrackingObject>();
            ArrayList arrCategoryList = new ArrayList();

            foreach (LG_Dashboard.Data.Session session in Sessions)
            {
                foreach (TrackingProduct tracking in session.TrackingProducts.ToList())
                {
                    Product product = db.Products.FirstOrDefault(x => x.ModelNumber.ToLower() == tracking.ModelNumber.ToLower());
                    TrackingType trackingType = dbtracking.TrackingTypes.FirstOrDefault(a => a.TrackingTypeId == tracking.TrackingTypeId);

                    if (!arrCategoryList.Contains(product.Categories.FirstOrDefault().DisplayName_EN))
                        arrCategoryList.Add(product.Categories.FirstOrDefault().DisplayName_EN);

                    TrackingObjectList.Add(new TrackingObject()
                    {
                        Name = product.Categories.FirstOrDefault().DisplayName_EN,
                        Price = (double)tracking.SalePrice,
                        TrackingTypeID = tracking.TrackingTypeId
                    });

                   
                }
            }

            for(int i=0; i<=arrCategoryList.Count && i <= 5 -1; i++)
            {
                int addToCartCount = 0;
                double categoryTotal = 0;
                foreach (TrackingObject to in TrackingObjectList.Where(x => x.Name == arrCategoryList[i].ToString()))
                {
                    addToCartCount += 1;
                    categoryTotal += to.Price;
                    if (to.TrackingTypeID == 4)
                        TotalPDFEmailCount += 1;
                }

                TopProductCategoryList.Add(new TopProductCategory()
                {
                    Name = arrCategoryList[i].ToString(),
                    AddtoCartCount = addToCartCount,
                    AverageDollarValue = categoryTotal / addToCartCount
                });

            }
            return TopProductCategoryList.OrderByDescending(x => Convert.ToInt32(x.AddtoCartCount)).ToList();

        }


        private List<AreaConfiguration> SessionDreamConfiguration(List<LG_Dashboard.Data.Session> Sessions)
        {
            List<AreaConfiguration> AreaConfigurationList = new List<AreaConfiguration>();
            List<TrackingConfiguration> TrackingConfigurationList = new List<TrackingConfiguration>();
            ArrayList arrAreaList = new ArrayList();

            foreach (LG_Dashboard.Data.Session session in Sessions)
            {
                foreach (TrackingProduct tracking in session.TrackingProducts.ToList())
                {
                    Product product = db.Products.FirstOrDefault(x => x.ModelNumber.ToLower() == tracking.ModelNumber.ToLower());
                    Area productArea = db.Areas.FirstOrDefault(a => a.AreaId == product.AreaId);

                    if (!arrAreaList.Contains(product.Area.AreaName))
                        arrAreaList.Add(product.Area.AreaName);

                    TrackingConfigurationList.Add(new TrackingConfiguration()
                    {
                        Name = product.Area.AreaName
                    });
                }
            }

            for (int v = 0; v <= arrAreaList.Count - 1; v++)
            {
                int sessionCount = 0;

                foreach (TrackingConfiguration to in TrackingConfigurationList.Where(x => x.Name == arrAreaList[v].ToString()))
                {
                    sessionCount += 1;
                }

                AreaConfigurationList.Add(new AreaConfiguration()
                {
                    Name = arrAreaList[v].ToString(),
                    Count = sessionCount
                });
            }

            return AreaConfigurationList;
        }




        private List<TopProductModel> TopProductModels(List<LG_Dashboard.Data.Session> Sessions)
        {
            List<TopProductModel> TopProductModelList = new List<TopProductModel>();
            List<TrackingModel> TrackingModelList = new List<TrackingModel>();
            ArrayList arrModelList = new ArrayList();

            foreach (LG_Dashboard.Data.Session session in Sessions)
            {
                foreach (TrackingProduct tracking in session.TrackingProducts.ToList())
                {
                    Product product = db.Products.FirstOrDefault(x => x.ModelNumber.ToLower() == tracking.ModelNumber.ToLower());
                    TrackingType trackingType = dbtracking.TrackingTypes.FirstOrDefault(a => a.TrackingTypeId == tracking.TrackingTypeId);

                    if (!arrModelList.Contains(product.ModelNumber))
                        arrModelList.Add(product.ModelNumber);

                    TrackingModelList.Add(new TrackingModel()
                    {
                        ModelNumber = product.ModelNumber
                    });
                }
            }

            for (int i = 0; i <= arrModelList.Count && i <= 10 - 1; i++)
            {
                int addToCartCount = 0;

                foreach (TrackingModel to in TrackingModelList.Where(x => x.ModelNumber == arrModelList[i].ToString()))
                {
                    addToCartCount += 1;
                }

                TopProductModelList.Add(new TopProductModel()
                {
                    ModelNumber = arrModelList[i].ToString(),
                    AddtoCartCount = addToCartCount,
                    Feature = "",
                    Colour = ""
                });
            }
            return TopProductModelList.OrderByDescending(x => Convert.ToInt32(x.AddtoCartCount)).ToList();
        }

    }
}
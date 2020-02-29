using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LG_Dashboard.Models
{
    public class DashboardViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime Date { get; set; }
        public int SessionCount { get; set; }
        public int TotalPDFEmailCount { get; set; }

        public List<TopProductCategory> TopProductCategories { get; set; }
        public List<AreaConfiguration> SessionDreamConfiguration { get; set; }
        public List<TopProductModel> TopProductModels { get; set; }
    }


    public class TopProductCategory
    {
        public string Name { get; set; }
        public int AddtoCartCount { get; set; }
        public double AverageDollarValue { get; set; }
    }

    public class TopProductModel
    {
        public string ModelNumber { get; set; }
        public int AddtoCartCount { get; set; }
        public string Feature { get; set; }
        public string Colour { get; set; }
    }

    public class TrackingObject
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int TrackingTypeID{ get; set; }

    }

    public class TrackingConfiguration
    {
        public string Name { get; set; }
    }

    public class TrackingModel
    {
        public string ModelNumber { get; set; }
    }


    public class AreaConfiguration
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

}
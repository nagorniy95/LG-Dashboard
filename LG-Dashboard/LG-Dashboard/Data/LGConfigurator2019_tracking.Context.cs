﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LG_Dashboard.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LGConfigurator2019_trackingEntities : DbContext
    {
        public LGConfigurator2019_trackingEntities()
            : base("name=LGConfigurator2019_trackingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AggregateFeature> AggregateFeatures { get; set; }
        public virtual DbSet<AggregateProduct> AggregateProducts { get; set; }
        public virtual DbSet<AggregateSearch> AggregateSearches { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TrackingFeature> TrackingFeatures { get; set; }
        public virtual DbSet<TrackingProduct> TrackingProducts { get; set; }
        public virtual DbSet<TrackingSearch> TrackingSearches { get; set; }
        public virtual DbSet<TrackingSystemLog> TrackingSystemLogs { get; set; }
        public virtual DbSet<TrackingType> TrackingTypes { get; set; }
    }
}

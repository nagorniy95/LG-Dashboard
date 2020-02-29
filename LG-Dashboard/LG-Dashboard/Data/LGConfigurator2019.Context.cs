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
    
    public partial class LGConfigurator2019Entities : DbContext
    {
        public LGConfigurator2019Entities()
            : base("name=LGConfigurator2019Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appliance> Appliances { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Furnishing> Furnishings { get; set; }
        public virtual DbSet<Hotspot> Hotspots { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageView> ImageViews { get; set; }
        public virtual DbSet<Preset> Presets { get; set; }
        public virtual DbSet<PresetFurnishingStyle> PresetFurnishingStyles { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductHotspotFeature> ProductHotspotFeatures { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public virtual DbSet<SpecificationImage> SpecificationImages { get; set; }
        public virtual DbSet<SpecificationType> SpecificationTypes { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
    }
}
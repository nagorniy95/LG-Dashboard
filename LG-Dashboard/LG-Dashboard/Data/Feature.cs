//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Feature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feature()
        {
            this.ProductHotspotFeatures = new HashSet<ProductHotspotFeature>();
        }
    
        public int FeatureId { get; set; }
        public string Name_EN { get; set; }
        public string Name_FR { get; set; }
        public string Description_EN { get; set; }
        public string Description_FR { get; set; }
        public string YoutubeVideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public string LogoUrl_EN { get; set; }
        public string LogoUrl_FR { get; set; }
        public bool IsFilterable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductHotspotFeature> ProductHotspotFeatures { get; set; }
    }
}

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
    
    public partial class AggregateFeature
    {
        public int AggregateFeatureId { get; set; }
        public int TrackingTypeId { get; set; }
        public int RetailerId { get; set; }
        public int FeatureId { get; set; }
        public int TotalCount { get; set; }
        public System.DateTime Timestamp { get; set; }
    
        public virtual Retailer Retailer { get; set; }
        public virtual TrackingType TrackingType { get; set; }
    }
}

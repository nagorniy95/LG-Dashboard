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
    
    public partial class TrackingSearch
    {
        public int TrackingSearchId { get; set; }
        public int SessionId { get; set; }
        public int TrackingTypeId { get; set; }
        public int ItemId { get; set; }
        public System.DateTime Timestamp { get; set; }
        public bool IsAggregated { get; set; }
    
        public virtual Session Session { get; set; }
        public virtual TrackingType TrackingType { get; set; }
    }
}

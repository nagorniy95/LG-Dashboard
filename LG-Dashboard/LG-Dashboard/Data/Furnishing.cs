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
    
    public partial class Furnishing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Furnishing()
        {
            this.PresetFurnishingStyles = new HashSet<PresetFurnishingStyle>();
        }
    
        public int FurnishingId { get; set; }
        public int AreaId { get; set; }
        public string Name_EN { get; set; }
        public string Name_FR { get; set; }
        public string InternalName { get; set; }
    
        public virtual Area Area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresetFurnishingStyle> PresetFurnishingStyles { get; set; }
    }
}
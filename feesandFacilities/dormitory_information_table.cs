//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace feesandFacilities
{
    using System;
    using System.Collections.Generic;
    
    public partial class dormitory_information_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dormitory_information_table()
        {
            this.dormitory_information_table_translation = new HashSet<dormitory_information_table_translation>();
        }
    
        public int id { get; set; }
        public int dormitory_type_id { get; set; }
    
        public virtual dormitory_type dormitory_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dormitory_information_table_translation> dormitory_information_table_translation { get; set; }
    }
}

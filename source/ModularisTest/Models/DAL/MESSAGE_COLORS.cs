//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModularisTest.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MESSAGE_COLORS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MESSAGE_COLORS()
        {
            this.MESSAGE_TYPES = new HashSet<MESSAGE_TYPES>();
        }
    
        public int ID { get; set; }
        public string COLOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGE_TYPES> MESSAGE_TYPES { get; set; }
    }
}
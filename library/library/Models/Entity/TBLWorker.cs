//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLWorker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLWorker()
        {
            this.TBLAction = new HashSet<TBLAction>();
        }
    
        public int WorkerID { get; set; }
        public string WorkerNameSurname { get; set; }
        public Nullable<int> LibraryID { get; set; }
        public string WorkerDetail { get; set; }
    
        public virtual Libraries Libraries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLAction> TBLAction { get; set; }
    }
}

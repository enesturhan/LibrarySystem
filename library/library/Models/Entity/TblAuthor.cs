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
    
    public partial class TblAuthor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblAuthor()
        {
            this.TBLBook = new HashSet<TBLBook>();
        }
    
        public int authorID { get; set; }
        public string authorName { get; set; }
        public string authorSurname { get; set; }
        public string authorDetail { get; set; }
        public Nullable<int> LibraryID { get; set; }
    
        public virtual Libraries Libraries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLBook> TBLBook { get; set; }
    }
}

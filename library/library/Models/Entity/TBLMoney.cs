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
    
    public partial class TBLMoney
    {
        public int ID { get; set; }
        public string Month { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public Nullable<int> LibraryID { get; set; }
    
        public virtual Libraries Libraries { get; set; }
    }
}

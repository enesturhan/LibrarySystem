﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryEntities : DbContext
    {
        public LibraryEntities()
            : base("name=LibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Libraries> Libraries { get; set; }
        public virtual DbSet<Library1> Library1 { get; set; }
        public virtual DbSet<Library2> Library2 { get; set; }
        public virtual DbSet<Library3> Library3 { get; set; }
        public virtual DbSet<Library4> Library4 { get; set; }
        public virtual DbSet<Library5> Library5 { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLAction> TBLAction { get; set; }
        public virtual DbSet<TblAuthor> TblAuthor { get; set; }
        public virtual DbSet<TBLBook> TBLBook { get; set; }
        public virtual DbSet<TBLCategory> TBLCategory { get; set; }
        public virtual DbSet<TBLMoney> TBLMoney { get; set; }
        public virtual DbSet<TBLPunishment> TBLPunishment { get; set; }
        public virtual DbSet<TBLUser> TBLUser { get; set; }
        public virtual DbSet<TBLWorker> TBLWorker { get; set; }
    }
}
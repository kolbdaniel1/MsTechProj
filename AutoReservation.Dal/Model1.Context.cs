﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoReservation.Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutoReservationEntities : DbContext
    {
        public AutoReservationEntities()
            : base("name=AutoReservationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autos> Autos { get; set; }
        public virtual DbSet<Kunden> Kundens { get; set; }
        public virtual DbSet<Reservationen> Reservationens { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fees_facilities_Entities : DbContext
    {
        public fees_facilities_Entities()
            : base("name=fees_facilities_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account_information_parameter> account_information_parameter { get; set; }
        public virtual DbSet<account_information_parameter_translation> account_information_parameter_translation { get; set; }
        public virtual DbSet<account_parameter_values> account_parameter_values { get; set; }
        public virtual DbSet<account_parameter_values_translation> account_parameter_values_translation { get; set; }
        public virtual DbSet<bank_currency_table> bank_currency_table { get; set; }
        public virtual DbSet<dormitories_table> dormitories_table { get; set; }
        public virtual DbSet<dormitories_table_translation> dormitories_table_translation { get; set; }
        public virtual DbSet<dormitory_bank_account_table> dormitory_bank_account_table { get; set; }
        public virtual DbSet<dormitory_information_table> dormitory_information_table { get; set; }
        public virtual DbSet<dormitory_information_table_translation> dormitory_information_table_translation { get; set; }
        public virtual DbSet<dormitory_type> dormitory_type { get; set; }
        public virtual DbSet<dormitory_type_translation> dormitory_type_translation { get; set; }
        public virtual DbSet<facility_option> facility_option { get; set; }
        public virtual DbSet<facility_option_translation> facility_option_translation { get; set; }
        public virtual DbSet<facility_table> facility_table { get; set; }
        public virtual DbSet<facility_table_translation> facility_table_translation { get; set; }
        public virtual DbSet<language_table> language_table { get; set; }
        public virtual DbSet<room_facility> room_facility { get; set; }
        public virtual DbSet<room_table> room_table { get; set; }
        public virtual DbSet<room_table_translation> room_table_translation { get; set; }
    }
}

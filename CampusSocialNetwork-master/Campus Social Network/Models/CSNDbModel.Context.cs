﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Campus_Social_Network.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CSNDBEntities : DbContext
    {
        public CSNDBEntities()
            : base("name=CSNDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddClass> AddClasses { get; set; }
        public virtual DbSet<AddStudent> AddStudents { get; set; }
        public virtual DbSet<AddTeacher> AddTeachers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminPassword> AdminPasswords { get; set; }
        public virtual DbSet<AdminPofilePhotoPath> AdminPofilePhotoPaths { get; set; }
    }
}

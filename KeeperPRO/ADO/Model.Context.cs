﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeeperPRO.ADO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KeeperPRODBEntities : DbContext
    {
        public KeeperPRODBEntities()
            : base("name=KeeperPRODBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Departament> Departaments { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Request_Client> Request_Client { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}

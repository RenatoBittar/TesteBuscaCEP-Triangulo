using Infrastructure.Entidades;
using Infrastructure.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Infrastructure.Controller
{
    class ControllersContext : DbContext
    {
        public ControllersContext() : base("Server=localhost\\SQLEXPRESS;DataBase=TesteCEP;Integrated Security=true; ")
        {

        }

        public DbSet<CEP> Cep { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ControllersContext>(null);
            modelBuilder.Configurations.Add(new CepMap());
            base.OnModelCreating(modelBuilder);
        }
    }

}

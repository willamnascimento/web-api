using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Data.configs;
using WebApi.Data.Models;

namespace WebApi.Data.context
{
    public class context : DbContext
    {
        public context()
            : base("name=context")
        {
        }

        public DbSet<account> accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new account_config());
        }
    }
}
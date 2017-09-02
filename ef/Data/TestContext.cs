using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ef.Data
{
    public class TestContext : DbContext
    {
        public DbSet<MainTable> MainTables { get; set; }
        public DbSet<SubTable> SubTables { get; set; }

        public TestContext() : base("Test")
        {
            Database.SetInitializer<TestContext>(new MigrateDatabaseToLatestVersion<TestContext, Migrations.Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
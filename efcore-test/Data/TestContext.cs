using Microsoft.EntityFrameworkCore;

namespace ef_test.Data
{
    public class TestContext : DbContext
    {
        public DbSet<MainTable> MainTables { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;Trusted_Connection=True;");
        }
    }
}
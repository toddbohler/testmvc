using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace testmvc.DTO
{
    public class SQLServerDbContext : DbContext {

        public DbSet<User> Users{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=TestMVC_DB; Trusted_Connection=True;");
        }
    }
}
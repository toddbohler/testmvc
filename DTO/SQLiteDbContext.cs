using Microsoft.EntityFrameworkCore;

public class SQLiteDbContext : DbContext {

    public DbSet<User> Users{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite(@"DataSource=mydb.db;");
    }
}
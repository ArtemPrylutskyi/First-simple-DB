using Microsoft.EntityFrameworkCore;

namespace App;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mydb;Username=myuser;Password=mypassword");
    }
}

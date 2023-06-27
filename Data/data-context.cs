using Microsoft.EntityFrameworkCore;
using firstproject.Entities;

namespace firstproject.Data{
public class DataContext : DbContext
{   
    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration){
        Configuration=configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
    public DbSet<Book> book { get;set;}
    public DbSet<User> user {get;set;}

}
}


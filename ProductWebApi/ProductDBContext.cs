using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductWebApi.Models;

namespace ProductWebApi
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> dbContextOptions): base(dbContextOptions)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(dbCreator != null)
                {   
                    // create db if cannot connect
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    //Create Tables if no tables exist
                    if(!dbCreator.HasTables()) dbCreator.CreateTables();
                }

            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);           
            }
        }

        public DbSet<Product> Products { get; set; }

    }
}

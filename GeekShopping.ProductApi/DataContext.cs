using GeekShopping.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi
{
    public class DataContext: DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> otions) : base(otions) 
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

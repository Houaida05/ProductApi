using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Models
{
    public class ProductContext :DbContext
    {
        public ProductContext(DbContextOptions<ProductContext>options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}

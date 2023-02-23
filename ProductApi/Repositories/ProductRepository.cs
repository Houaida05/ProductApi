using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using System;

namespace ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.ToListAsync();
        }
        public async Task<Product> GetProduct(int productId)
        {
            return await _productContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var result = await _productContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (result != null)
            {
                _productContext.Products.Remove(result);
                await _productContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Product> UpdateProduct(Product Product)
        {
            {
                var result = await _productContext.Products
                    .FirstOrDefaultAsync(p => p.ProductId == Product.ProductId);
                if (result != null)
                {
                    result.Name = Product.Name;
                    result.Description = Product.Description;
                    result.Price = Product.Price;
                    await _productContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
        }
    }
}
        


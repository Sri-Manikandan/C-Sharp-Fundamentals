using ProductsAPI.DTOs;
using ProductsAPI.Models;
using ProductsAPI.Repository;

namespace ProductsAPI.Services{
    public class ProductService : IProductService{
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository repo, ILogger<ProductService> logger){
            _repo   = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(){
            _logger.LogInformation("Fetching all products.");
            return await _repo.GetAllAsync();
        }
        public async Task<Product?> GetByIdAsync(int id){
            _logger.LogInformation("Fetching product ID: {Id}", id);

            return await _repo.GetByIdAsync(id);
        }


        public async Task<Product> CreateAsync(ProductDto dto){
            var product = new Product{
                Name  = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            await _repo.AddAsync(product);
            await _repo.SaveAsync();

            _logger.LogInformation("Created product: {Name}", product.Name);
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, ProductDto dto){
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;

            product.Name  = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            await _repo.UpdateAsync(product);
            await _repo.SaveAsync();
            _logger.LogInformation("Updated product ID: {Id}", id);
            return product;
        }
        public async Task<bool> DeleteAsync(int id){
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            await _repo.DeleteAsync(product);
            await _repo.SaveAsync();

            _logger.LogInformation("Deleted product ID: {Id}", id);
            return true;
        }
    }
}

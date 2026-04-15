using ProductsAPI.Models;

namespace ProductsAPI.Repository{
    public interface IProductRepository{
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task SaveAsync();
    }
}
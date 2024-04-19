using AzureWebAppDemo.Models;

namespace AzureWebAppDemo.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int Id);
        Task<Product> AddProduct(Product product);
        Task<int> DeleteProduct(int Id);
        Task<Product> UpdateProduct(Product product);
    }
}

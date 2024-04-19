using AzureWebAppDemo.Models;
using Dapper;
using System.Data;

namespace AzureWebAppDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbConnection _dbConnection;
        public ProductService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var parameters = new DynamicParameters();
            product.ProductId = await _dbConnection.ExecuteScalarAsync<int>("SELECT MAX(ProductId)+1 ProductId FROM Products WHERE IsDeleted = 0");
            parameters.Add("ProductId", product.ProductId);
            parameters.Add("ProductName", product.ProductName);
            parameters.Add("Quantity", product.Quantity); 
            await _dbConnection.ExecuteAsync("INSERT INTO Products(ProductId,ProductName,Quantity) VALUES(@ProductId,@ProductName,@Quantity)", parameters);
            return product;
        }

        public async Task<int> DeleteProduct(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", Id);
            await _dbConnection.ExecuteAsync("Update Products SET IsDeleted = 1 WHERE ProductId = @ProductId", parameters);
            return Id;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", Id);
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE IsDeleted = 0 AND ProductId = @ProductId", parameters);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbConnection.QueryAsync<Product>("SELECT * FROM Products WHERE IsDeleted = 0");
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", product.ProductId);
            parameters.Add("ProductName", product.ProductName);
            parameters.Add("Quantity", product.Quantity);
            await _dbConnection.ExecuteAsync("UPDATE Products SET ProductName = @ProductName,Quantity = @Quantity WHERE ProductId = @ProductId", parameters);
            return product;
        }
    }
}

using AzureWebAppDemo.Models;
using AzureWebAppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureWebAppDemo.Pages.ProductViews
{
    public class DeleteProductModel : PageModel
    {
        private readonly ILogger<DeleteProductModel> _logger;
        private readonly IProductService _productService;
        public Product product;

        public DeleteProductModel(ILogger<DeleteProductModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task OnGet(int id)
        {
            product = await _productService.GetProductById(id);
        }

        public async Task OnPost(Product product)
        {
            int id = await _productService.DeleteProduct((int)product.ProductId);

        }
    }
}

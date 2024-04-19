using AzureWebAppDemo.Models;
using AzureWebAppDemo.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureWebAppDemo.Pages.ProductViews
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ILogger<ProductDetailsModel> _logger;
        private readonly IProductService _productService;
        public Product product;

        public ProductDetailsModel(ILogger<ProductDetailsModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task OnGet(int id)
        {
            product = await _productService.GetProductById(id);
        }
    }
}

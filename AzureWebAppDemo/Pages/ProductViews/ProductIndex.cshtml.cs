using AzureWebAppDemo.Models;
using AzureWebAppDemo.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureWebAppDemo.Pages.ProductViews
{
    public class ProductIndexModel : PageModel
    {
        private readonly ILogger<ProductIndexModel> _logger;
        private readonly IProductService _productService;
        public IEnumerable<Product> products;
        public ProductIndexModel(ILogger<ProductIndexModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task OnGet()
        {
            products = await _productService.GetProducts();
        }
    }
}

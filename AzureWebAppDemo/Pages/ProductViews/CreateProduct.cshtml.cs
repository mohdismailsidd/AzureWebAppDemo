using AzureWebAppDemo.Models;
using AzureWebAppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureWebAppDemo.Pages.ProductViews
{
    public class CreateProductModel : PageModel
    {
        private readonly ILogger<CreateProductModel> _logger;
        private readonly IProductService _productService;
        public Product product;

        public CreateProductModel(ILogger<CreateProductModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task OnGet(int id)
        {
            product = new Product();
        }

        public async Task OnPost(Product product)
        {
            product = await _productService.AddProduct(product);
        }
    }
}

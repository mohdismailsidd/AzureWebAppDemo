using AzureWebAppDemo.Models;
using AzureWebAppDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureWebAppDemo.Pages.ProductViews
{
    public class EditProductModel : PageModel
    {
        private readonly ILogger<EditProductModel> _logger;
        private readonly IProductService _productService;
        public Product product;

        public EditProductModel(ILogger<EditProductModel> logger, IProductService productService)
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
            product = await _productService.UpdateProduct(product);
        }
    }
}

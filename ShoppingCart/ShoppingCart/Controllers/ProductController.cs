using Microsoft.AspNetCore.Mvc;
using ShoppinCart.DAL.ViewModels;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _productService.AddProductAsync(model);

            return Ok();
        }
    }
}

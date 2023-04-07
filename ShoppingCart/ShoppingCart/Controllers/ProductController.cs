using Microsoft.AspNetCore.Mvc;
using ShoppinCart.DAL.ViewModels;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUploadService _uploadService;

        public ProductController(IProductService productService, IUploadService uploadService)
        {
            _productService = productService;
            _uploadService = uploadService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromForm] ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.FirstOrDefault();
            await _uploadService.UploadPhoto(file);

            await _productService.AddProductAsync(model);

            return Ok();
        }
    }
}

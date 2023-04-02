using ShoppinCart.DAL;
using ShoppinCart.DAL.Entities;
using ShoppinCart.DAL.ViewModels;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Service.BLL
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;

        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddProductAsync(ProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                ImagePath = model.ImagePath,
                Price = model.Price
            };

            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}

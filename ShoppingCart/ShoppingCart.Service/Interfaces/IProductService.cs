using ShoppinCart.DAL.Entities;
using ShoppinCart.DAL.ViewModels;

namespace ShoppingCart.Service.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductViewModel model);
        Task<List<Product>> GetProducts();
    }
}

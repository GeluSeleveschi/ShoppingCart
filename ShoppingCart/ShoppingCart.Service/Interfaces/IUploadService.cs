using Microsoft.AspNetCore.Http;

namespace ShoppingCart.Service.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadPhoto(IFormFile file);
    }
}

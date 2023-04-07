using Microsoft.AspNetCore.Http;

namespace ShoppinCart.DAL.ViewModels
{
    public class ProductViewModel
    {
        //public string Name { get; set; }
        //public string? ImagePath { get; set; }
        //public string Description { get; set; }
        //public decimal? Price { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ImagePath { get; set; }
    }
}

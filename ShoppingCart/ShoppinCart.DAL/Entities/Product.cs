namespace ShoppinCart.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}

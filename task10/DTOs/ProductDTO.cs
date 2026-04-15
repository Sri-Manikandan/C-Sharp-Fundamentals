namespace ProductsAPI.DTOs{
    public class ProductDto{
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
namespace ToyStore.WebApp.Models
{
    /// <summary>
    /// View model for updates
    /// </summary>
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}

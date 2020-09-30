namespace ToyStore.WebApp.Models
{
    /// <summary>
    /// View model for new products
    /// </summary>
    public class NewProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}

namespace ToyStore.WebApp.Models
{
    /// <summary>
    /// View model for lists
    /// </summary>
    public class ProductForListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}

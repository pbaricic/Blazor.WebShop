namespace Expert.WebShop.Zavrsni.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int NumberOfItems { get; set; }
        public string OrderedByName { get; set; }
        public string OrderedByEmail { get; set; }
        public string OrderId { get; set; }
    }
}

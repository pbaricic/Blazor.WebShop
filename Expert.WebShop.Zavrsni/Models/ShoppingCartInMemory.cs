using System.Net.Http.Json;


namespace Expert.WebShop.Zavrsni.Models
{
    public class ShoppingCartInMemory
    {
        private readonly HttpClient _httpClient;
        public List<ShoppingCart> SelectedItems { get; set; } = new();

        //Konstruktor klase ide sada 

        public ShoppingCartInMemory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddToShoppingCart(int productId)
        {
            if (SelectedItems.FirstOrDefault(x => x.ProductId == productId) == null)
            {
                var result = await _httpClient.GetAsync($"https://expertshopapi.azurewebsites.net/api/Products/{productId}");
                if (result.IsSuccessStatusCode)
                {
                    var addProduct = await result.Content.ReadFromJsonAsync<Product>();
                    ShoppingCart addToList = new ShoppingCart();
                    addToList.Product = addProduct;
                    addToList.ProductId = addProduct.Id;
                    addToList.NumberOfItems = 1;
                    SelectedItems.Add(addToList);
                }
            }
            else
            {
                var increase = SelectedItems.FirstOrDefault(x => x.ProductId == productId);
                SelectedItems.Remove(increase);
                increase.NumberOfItems = increase.NumberOfItems + 1;
                SelectedItems.Add(increase);
            }
        }
    }
}

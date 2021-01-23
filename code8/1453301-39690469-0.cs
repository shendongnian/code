    public class Client
    {
        private Uri baseAddress;
    
        public Client(Uri baseAddress)
        {
            this.baseAddress = baseAddress;
        }
    
        public IEnumerable<Products> GetProductsFromCategory(int categoryId)
        {
             return Get<IEnumerable<Product>>($"api/categories/{categoryId}/products");
        }
    
        public IEnumerable<Products> GetAllProducts()
        {
             return Get<IEnumerable<Product>>($"api/products");
        }
    
        private T Get<T>(string query)
        {
            using(var httpClient = new HttpClient())
            {
                 httpClient.BaseAddress = baseAddress;
    
                 var response= httpClient.Get(query).Result;
                 return response.Content.ReadAsAsync<T>().Result;
            }
        }
    }

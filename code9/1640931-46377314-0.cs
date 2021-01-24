    static async Task<List<Product>> GetAllProductsAsync(string path)
    {
        List<Product> products = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            products = await response.Content.ReadAsAsync<List<Product>>();
        }
        return products;
    }

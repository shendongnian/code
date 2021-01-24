        Product product = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
          product = await response.Content.ReadAsAsync<Product>();
        }
        return product;

    string url = "http://url.of.server/";
    Pedro product = new Pedro();
    product.FirtsName = "Ola";
    product.ID = 1;
    product.Idade = 10;
    using (var client = new HttpClient())
    {
           client.BaseAddress = new Uri(url);
           client.DefaultRequestHeaders.Accept.Clear();
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
           HttpResponseMessage response = client.PostAsJsonAsync(url, product).Result;
           if (response.IsSuccessStatusCode)
           {
                // do something
           }
    }

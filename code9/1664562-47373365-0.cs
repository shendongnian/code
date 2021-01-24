    public static async Task<ProductOrderBook> GetProductOrderBook()
    {
        string ts = GetNonce();
        string method = "/products/BTC-USD/book?level=2";
        string sig = GetSignature(ts, "GET", method, string.Empty);
        ProductOrderBook productOrderBooks;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("CB-ACCESS-KEY", apiKey);
            client.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
            client.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
            client.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", passphrase);
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);
    
            HttpResponseMessage response = client.GetAsync(method).Result;
            string json = await response.Content.ReadAsStringAsync();
            productOrderBooks = JsonConvert.DeserializeObject<LProductOrderBook>(json);
            }
            return await Task.Run(() => new productOrderBooks);            
        }

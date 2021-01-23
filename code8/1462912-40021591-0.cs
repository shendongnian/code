    var client = new HttpClient();
    
    using (HttpRequestMessage request = new HttpRequestMessage())
    {
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(Constants.Cielo.GetSalesUrl(), UriKind.Absolute);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var requestContent = JsonConvert.SerializeObject(sale);
        request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
    
        request.Headers.Add("MerchantId", Constants.Cielo.Sandbox.MerchantId.ToString());
        request.Headers.Add("MerchantKey", Constants.Cielo.Sandbox.MerchantKey);
        
        using (HttpResponseMessage response = await client.SendAsync(request))
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.Content != null)
                {
                    var rawJson = await response.Content.ReadAsStringAsync();
                    // do stuff - map to type, etc.
                }
            }
    
            return something;
        }
    }

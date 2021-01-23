        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri( @"http://localhost:5000");
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                
    
                HttpContent content = new StringContent(@"<Product>
            <Id>122</Id>
            <Name>Computer112</Name>
        </Product>",System.Text.Encoding.UTF8 , "application/xml");  // This is important.
    
                var result = client.PostAsync("/api/Products", content).Result;

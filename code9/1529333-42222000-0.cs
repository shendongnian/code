    using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiDetails.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                HttpResponseMessage response = client.PostAsJsonAsync(apiDetails.RequestUrl, obj).Result;                
            }

    public async Task<Model> GetData(string url)
            {           
                HttpClient httpClient = new HttpClient();
    
                httpClient.BaseAddress = new Uri(url);
    
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                HttpResponseMessage result = await httpClient.GetAsync(url);
    
                if (result.IsSuccessStatusCode)
                {
                    string contentResult = await result.Content.ReadAsStringAsync();
    
                    Model newModel = JsonConvert.DeserializeObject<Model>(contentResult);
    
                }
    
                return newModel;
            }

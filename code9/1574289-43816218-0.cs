     private string URL = "Your Base domain URL";
     public async Task<YourModel> getRequest()
            {
                using (var Client = new HttpClient())
                {
                    Client.BaseAddress = new Uri(URL);
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    HttpResponseMessage responce = await Client.GetAsync("Your Method or the API you callig");
                    if (responce.IsSuccessStatusCode)
                    {
                        var Json = await responce.Content.ReadAsStringAsync();
                        var Items= JsonConvert.DeserializeObject<YourModel>(Json);
    
                    // now use you have the date on Items !
                        return Items;
                    }
                    else
                    {
                        // deal with error or here ...
                        return null;
                    }
                }
            }

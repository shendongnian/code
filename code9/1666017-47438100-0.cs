                using (var client = new HttpClient())
                {
                    var response = client.GetAsync("http://api.tradeskillmaster.com/v1/item/EU/ragnaros/82800?format=json&apiKey=test").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync();
                        var resultObject = JsonConvert.DeserializeObject<yourobject>(result.Result);
                        return resultObject;
                    }
                }

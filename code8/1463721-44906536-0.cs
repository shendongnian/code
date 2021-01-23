     HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://myurl/api");
                string json = JsonConvert.SerializeObject(myObj);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient http = new HttpClient();
                HttpResponseMessage response = await http.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                }

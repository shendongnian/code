                var client = new System.Net.Http.HttpClient();
    
                var content = new     StringContent(JsonConvert.SerializeObject(data));
                client.BaseAddress = new Uri("http://localhost:52733/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("set", content).Result;
                //do what ever you want to do with response

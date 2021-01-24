    string uri = "/api/ExtraNet/GetActivityList";
    
                HttpClient client = new HttpClient();
    
                int SalesPersonId = 553;
                string token = "";
    
                client.BaseAddress = new Uri("http://localhost:16513/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    
                var stringContent = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string,string>("SalesPersonId","553")
                });
    
                var response = await client.PostAsync(uri, stringContent);
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

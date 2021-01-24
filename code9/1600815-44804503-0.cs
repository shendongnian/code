            using (var httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = await httpClient.GetAsync(url);
                var data = await response.Content.ReadAsStringAsync();
                Dictionary<string, string> ValueList = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            }

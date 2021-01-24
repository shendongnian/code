        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("https://esi.tech.ccp.is/latest/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            GetTaskAsync("status/?datasource=tranquility").Wait();
        }
        static async Task GetTaskAsync(String endpoint)
        {
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + endpoint);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync();
                Console.WriteLine(data);
            }
        }

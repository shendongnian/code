            using ( HttpResponseMessage response = await client.GetAsync("WebApi/CaseLogs/v10/Search?DateFrom=04-05-2012"))
            using (HttpContent content = response.Content)
            {            
                string result = await content.ReadAsStringAsync();
                Console.WriteLine(result);
            }

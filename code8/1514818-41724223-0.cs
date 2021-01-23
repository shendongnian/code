        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(@"http://yourEndPoint.com");
            HttpContent content = new StringContent("{'json' : 'value'}", Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/endpoint", content);
            var contentAsString = await result.Content.ReadAsStringAsync();
        }

        public async Task<string> MyMethod1Async()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("SomeBaseAddress");
                // This will return control to the method's caller until this gets a result from the server
                HttpResponseMessage message = await client.GetAsync("SomeURI");
                // The same as above - returns control to the method's caller until this is done
                string content = await message.Content.ReadAsStringAsync();
                return content;
            }
        }

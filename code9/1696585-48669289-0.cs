        public void MethodName()
        {
            var returnedIp = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.BaseAddress = new Uri("https://foo.com");
                returnedIp = await GetSecret(client);
            }
        }

        public async Task<TResult> GetAsync<TResult>(string uriString) where TResult : class
        {
            var uri = new Uri(uriString);
            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    //Log.Error(response.ReasonPhrase);
                    return default(TResult);
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(json, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
        }
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            var username = // get your username
            var password = // get your password
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

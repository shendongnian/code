    public async Task<TResult> PostAsync<TResult, TInput>(string uriString, TInput payload = null) where TInput : class
        {
            var uri = new Uri(uriString);
            using (var client = GetHttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(payload, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                HttpResponseMessage response = await client.PostAsync(uri, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    //Log.Error(response.ReasonPhrase);
                    return default(TResult);
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(json);
            }
        }
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            var username = //get username
            var password = // get password
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

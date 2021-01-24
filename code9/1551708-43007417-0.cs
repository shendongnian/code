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

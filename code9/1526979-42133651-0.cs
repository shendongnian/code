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

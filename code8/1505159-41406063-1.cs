    public static async Task<T> GetResultFromApi<T>(string serviceUrl)
        {
            try
            {
				GetConnection();
                 var response = await _httpClient.GetAsync(new Uri(yourUrl + serviceUrl));
                var stringAsync = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = stringAsync;
                    return JsonConvert.DeserializeObject<T>(responseJson);
                }
                LoggingManager.Error("Received error response: " + stringAsync);
                return default(T);
            }
            catch (Exception exception)
            {
                LoggingManager.Error(exception);
                return default(T);
            }
        }
    var gettingDto = await GetResultFromApi<SampleDto>(string.Format(client.BaseAddress));

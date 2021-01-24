    public static async Task<SetupWebApiResponse> GetResponseAsync(string 
            endpoint)
        {
            string result = "";
            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                result = await content.ReadAsStringAsync();
            }
            return new SetupWebApiResponse(response.StatusCode, result);
        }

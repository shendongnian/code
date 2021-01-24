    public async Task<StellaData> GetStellConfigData()
    {
        try
        {
            using (var client = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(30000)
            })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(new Uri(Constants.mUrl));
                HttpStatusCode statusCode = response.StatusCode;
                var myItems = Newtonsoft.Json.JsonConvert.DeserializeObject<StellaData>(response);
                return myItems;
            }
        }
        catch (TaskCanceledException tcex)
        {
            // The request timed out
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        return null;
    }

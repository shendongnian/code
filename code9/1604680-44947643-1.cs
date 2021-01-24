        public async Task<T> CalWebApiAsync<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (var response = await request.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var stringResult = await streamReader.ReadToEndAsync();
                        T objectResult = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringResult);
                        return objectResult;
                    }
                }
            }
        }
var result = await CallWebApiAsync<YourType>("exteranlapiurl");

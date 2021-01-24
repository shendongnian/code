    public static class HttpRequestHelper
        {
            public static async Task<T> GetDataModelFromRequestBodyAsync<T>(HttpRequestMessage req)
            {
                dynamic requestBody = await req.Content.ReadAsStringAsync();
                object blobModelObject = JsonConvert.DeserializeObject<object>(requestBody);
                var blobModel = ((JObject)blobModelObject).ToObject<T>();
    
                return blobModel;
            }
        }

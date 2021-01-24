         public T CalWebApi<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var stringResult = streamReader.ReadToEnd();
                        T objectResult = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringResult);
                        return objectResult;
                    }
                }
            }
        }
var result = CallWebApi<YourType>("exteranlapiurl");

      static void Main(string[] args)
            {
                var applicationId = "xxxxxxxx";
                var applicationKey = "xxxxxxxx";
                var queryPath = "performanceCounters/processCpuPercentage";
                var queryType = "metrics";
                var str = GetTelemetry(applicationId, applicationKey, queryType, queryPath, "");
    
              
            }
     public static string GetTelemetry(string appid, string apikey,
                string queryType, string queryPath, string parameterString)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", apikey);
                var req = string.Format(Url, appid, queryType, queryPath, parameterString);
                HttpResponseMessage response = client.GetAsync(req).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return response.ReasonPhrase;
                }
            }

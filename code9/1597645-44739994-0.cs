    public class DataService
    {
        public static object ReceivedData(string queryString)
        {
            // Exec the query
            dynamic data = null;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(queryString).Result;
                // If result is not null, deserialize json
                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject(json);
                }
                
            }
                
            // Return json result
            return data;
        }
    }

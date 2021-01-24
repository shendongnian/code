        public static Object GetObject(string cacheKey)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:53805/api/NonPersisted/Get/" + cacheKey).Result;
                var obj = JsonConvert.DeserializeObject(response.Content.ToString());
                return obj;
            }
        }

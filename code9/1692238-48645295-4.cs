    public class TestClient
    {
        private static HttpClient client;
        private static string BASE_URL = "http://localhost:8080/";
        static TestClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> runbatchfile(string fileName)
        {
            var endpoint = string.Format("runbatchfile/{0}", fileName);
            var response = await client.GetAsync(endpoint);
            return await response.Content.ReadAsStringAsync();
        }
    }

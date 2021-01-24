    public class RestfulClient
    {
        private static HttpClient client;
        private static string BASE_URL = "http://localhost:8080/";
        static RestfulClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> addition(int firstNumber, int secondNumber)
        {
                var endpoint = string.Format("addition/{0}/{1}", firstNumber, secondNumber);
                var response = await client.GetAsync(endpoint);
                return await response.Content.ReadAsStringAsync();
         } 
    }

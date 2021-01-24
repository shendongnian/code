    public class RestfulClient {
        private static HttpClient client;
        private string BASE_URL = "http://localhost:8080/";
        static RestfulClient() {
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> addition(int a, int b) {
            try {
                var endpoint = string.Format("addition/{0}/{1}", a, b);
                var response = await client.GetAsync(endpoint);
                return await response.Content.ReadAsStringAsync();                 
            } catch (Exception e) {
                HttpContext.Current.Server.Transfer("ErrorPage.html");
            }
            return null;
        }
    }

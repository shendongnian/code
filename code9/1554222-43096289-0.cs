    class Program
    {
        static void Main(string[] args)
        {
            var task = MakeRequest();
            task.Wait();
            var response = task.Result;
            var body = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(body);
            Console.Read();
        }
        private static async Task<HttpResponseMessage> MakeRequest()
        {
            var httpClient = new HttpClient();
            HttpContent requestContent = new StringContent("I am the message body");
            
            return await httpClient.PostAsync("https://requestb.in/188bhf01", requestContent);
        }
    }

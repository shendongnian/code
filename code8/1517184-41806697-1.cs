    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main()
        {
            string responsePayload = Upload().GetAwaiter().GetResult();
            Console.WriteLine(responsePayload);
        }
        private static async Task<string> Upload()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8180/api/upload");
            var content = new MultipartFormDataContent();
            byte[] byteArray = ... get your image payload from somewhere
            content.Add(new ByteArrayContent(byteArray), "file", "file.jpg");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

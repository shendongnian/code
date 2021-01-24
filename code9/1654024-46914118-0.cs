    public class Client
    {
       private readonly string baseUri;
       private static HttpClient _client;
        public Client(string baseUri)
        {
            this.baseUri = baseUri;
            _client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true })
            {
                BaseAddress = new Uri(baseUri)
            };
            
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
  
        public async Task<SomeResource> GetResourceById(int Id)
        {
            var path = $"{baseUri}/Resources/{Id}";
            var response = await _client.GetAsync(path);
            return await response.Content.ReadAsAsync<SomeResource>();           
        }

    public class MyController
    {
        private readonly ISomeApiClient _client;
        
        public MyController(ISomeApiClient client)
        {
            _client = client;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAsync(string query)
        {
            var response = await _client.GetSomethingAsync(query);
    
            // Do something with response
    
            return Ok();
        }
    }

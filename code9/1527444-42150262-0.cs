     [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
             using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "Enter your key here");
                  
                    var uri = new Uri("uri to external API here + any parameters");
                    var response = await client.GetStringAsync(uri);
                    var jsonResponse =  JsonConvert.DeserializeObject(response); 
                    return Ok(jsonResponse); 
                }
        }

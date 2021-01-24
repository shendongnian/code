	public class DocumentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostDocument([FromBody] Container data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data.Document)) return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent, "No document attached"));
                return ResponseMessage(IndexDocument(data, Request));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message));
            }
        }
    }
	
	
    public class InsuranceContainer
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("document")]
        public string Document { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
	
	
    var fileAsBytes = File.ReadAllBytes(@"C:\temp\tmp62.pdf");
    String asBase64String = Convert.ToBase64String(fileAsBytes);
    var newModel = new InsuranceContainer
        {
           Document = asBase64String,
           Text = "Test document",
        };
    string json = JsonConvert.SerializeObject(newModel);
    using (var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json"))
        using (var client = new HttpClient())
        {
            var response = await client.PostAsync("https://www.mysite.dk/WebService/api/Document/PostDocument", stringContent);
            Console.WriteLine(response.StatusCode);
            var message = response.Content.ReadAsStringAsync();
            Console.WriteLine(message.Result);
        }

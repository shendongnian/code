        [HttpGet()]
        public async Task<HttpResponseMessage> Download()
        {
            string jsonData = "example data";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
    
    var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(byteArray)};
    			result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    			result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(Inline) { FileName = "testFile.json" };
    			return result;
            
        }

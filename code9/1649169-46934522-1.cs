        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            // get the form data posted and split the content into form data and files
            var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());
            // access form data
            NameValueCollection formData = provider.FormData;
            List<HttpContent> files = provider.Files;
            // Do something with files and form data
            return Ok();
        }
    

        [HttpGet]
        [Route("test")]
        public HttpResponseMessage Test()
        {
            const string json = "{ \"test\": 123 }";  // from RestClient
            var res = Request.CreateResponse();
            res.Content = new StringContent(json);
            res.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            return res;
        }

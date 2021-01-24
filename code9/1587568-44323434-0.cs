    [HttpGet]
        [Route("v1/test", Name = "test")]
        public HttpResponseMessage GetTest()
        {
            UriBuilder uriBuilder = new UriBuilder($"https://...../...");
            var webRequest = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Accept = "application/json, text/javascript, */*";
            using (var jsonResponse = (HttpWebResponse) webRequest.GetResponse())
            {
                var jsonStream = jsonResponse.GetResponseStream();
                MemoryStream ms = new MemoryStream();
                jsonStream.CopyTo(ms);
                ms.Position = 0;
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return response;
            }            
        }

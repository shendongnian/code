        [HttpGet]
        [Route("csv")]
        public HttpResponseMessage SomeMethod([FromUri]SomeSearchCriteria sc)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                string content = "test";
                writer.Write(content);
                writer.Flush();
                stream.Position = 0;
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                //result.Content = new StreamContent(stream);
                result.Content = new ByteArrayContent(stream.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
                return result;
            }
        }
 

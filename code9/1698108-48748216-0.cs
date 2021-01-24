    [HttpGet]
            [Route("api/Data/OpenPDF")]
            public HttpResponseMessage OpenPDF()
            {
                var stream = new MemoryStream();            
                using (FileStream fileStream = File.OpenRead(@"D:\PDF\pdf-test.pdf"))
                {
                    stream = new MemoryStream();
                    stream.SetLength(fileStream.Length);                
                    fileStream.Read(stream.GetBuffer(), 0, (int)fileStream.Length);
                }
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(stream.ToArray())
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue(System.Net.Mime.DispositionTypeNames.Inline)
                {
                    FileName = "file.pdf"
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                return result;
            }

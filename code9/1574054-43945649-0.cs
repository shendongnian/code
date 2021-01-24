        [HttpGet]
        public async Task<HttpResponseMessage> Download(CancellationToken token)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new PushStreamContent(async (stream, context, transportContext) =>
                {
                    try
                    {
                        using (var fileStream = System.IO.File.OpenRead("some path to MyBigDownload.zip"))
                        {
                            await fileStream.CopyToAsync(stream);
                        }
                    }
                    finally
                    {
                        stream.Close();
                    }
                }, "application/octet-stream"),
            };
            response.Headers.TransferEncodingChunked = true;
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "MyBigDownload.zip"
            };
            return response;
        }

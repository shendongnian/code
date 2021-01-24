        public async Task<HttpResponseMessage> GetExcel()
        {
         var stream = await MakeReport();
            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            result.Content.Headers.ContentLength = stream.Length;
            result.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddDays(-1));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("Attachment") { FileName = "Report.xlsx" };
            WriteFileToResponse(stream, result);
            return result;
        }
        protected override void WriteFileToResponse(Stream _stream, Response _response)
        {
            Stream _responseStream = _response.OutputStream;
            byte[] buffer = new byte[4096];
            while (true)
            {
                int num = this._stream.Read(buffer, 0, 4096);
                if (num == 0)
                {
                    break;
                }
                _responseStream.Write(buffer, 0, num);
            }
        }

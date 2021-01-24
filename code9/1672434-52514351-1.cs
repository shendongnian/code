        [HttpGet]
        public HttpResponseMessage Video(string id)
        {
            bool rangeMode = false;
            int startByte = 0;
            if (Request.Headers.Range != null)
                if (Request.Headers.Range.Ranges.Any())
                {
                    rangeMode = true;
                    var range = Request.Headers.Range.Ranges.First();
                    startByte = Convert.ToInt32(range.From ?? 0);
                }
            var stream = new FileStream(/* FILE NAME - convert id to file somehow */, FileMode.Open, FileAccess.Read, FileShare.ReadWrite) {Position = startByte};
            if (rangeMode)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.PartialContent)
                {
                    Content = new ByteRangeStreamContent(stream, Request.Headers.Range, MediaTypeHeaderValue.Parse(fileDetails.MimeType))
                };
                response.Headers.AcceptRanges.Add("bytes");
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(stream)
                };
                response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(fileDetails.MimeType);
                return response;
            }
        }

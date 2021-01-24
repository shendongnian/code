        public async Task<IHttpActionResult> Post()
        {
            var provider = new MultipartMemoryStreamProvider();
            var stream = await Request.Content.ReadAsMultipartAsync(provider).ConfigureAwait(false);
            // Returns the first file it finds
            var fileStream = stream.Contents.FirstOrDefault(x => x.Headers.ContentDisposition.FileName != null);
            // return a result
        }

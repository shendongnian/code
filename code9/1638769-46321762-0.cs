    public IHttpActionResult Post()
        {
            var stream = HttpContext.Current.Request.GetBufferlessInputStream(true);
            // Begin Upload
            HostingEnvironment.QueueBackgroundWorkItem(async cancellationToken => await BeginUpload(stream));
            //  Return upload begin successful
            return Ok($"Upload started! # {0}");
        }
        private async Task BeginUpload(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var index = 0;
                var buffer = new char[100000000];
                while (!reader.EndOfStream)
                {
                    await reader.ReadBlockAsync(buffer, index, 1024);
                    index += 1024;
                    Debug.Write($"{index}\n");
                }
            }
        }

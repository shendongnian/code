    public abstract class FileActionResult : IHttpActionResult
        {
            private string MediaType { get; }
            private string FileName { get; }
            private Stream Data { get; }
    
            protected FileActionResult(Stream data, string fileName, string mediaType)
            {
                Data = data;
                FileName = fileName;
                MediaType = mediaType;
            }
    
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                Data.Position = 0;
                var response = new HttpResponseMessage
                {
                    Content = new StreamContent(Data)
                };
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);
                response.Content.Headers.ContentDisposition.FileName = FileName;
                response.Content.Headers.ContentLength = Data.Length;
    
                return Task.FromResult(response);
            }
    
        }
    
        public class ExcelFileActionResult : FileActionResult
        {
            public ExcelFileActionResult(Stream data) : base(data, "Exported.xls", "application/vnd.ms-excel")
            {
            }
        }

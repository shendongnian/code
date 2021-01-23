    public class StreamInputFormatter : IInputFormatter
    {
        // enter your list here...
        private readonly List<string> _allowedMimeTypes = new List<string>
            { "application/pdf", "image/jpg", "image/jpeg", "image/png", "image/tiff", "image/tif", "application/octet-stream" };
    
    
        public bool CanRead(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var contentType = context.HttpContext.Request.ContentType;
            if (_allowedMimeTypes.Any(x => x.Contains(contentType)))
            {
                return true;
            }
            return false;
        }
    
        public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
 
            // enable stream rewind or you won't be able to read the file in the controller   
            var req = context.HttpContext.Request;
            req.EnableRewind();
            var memoryStream = new MemoryStream();
            context.HttpContext.Request.Body.CopyTo(memoryStream);
            req.Body.Seek(0, SeekOrigin.Begin);
            return InputFormatterResult.SuccessAsync(memoryStream);
        }
    }

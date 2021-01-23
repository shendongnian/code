    public class CustomFormatter : MediaTypeFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }
        public override bool CanReadType(Type type)
        {
            return type == typeof(Attachment);
        }
        public override bool CanWriteType(Type type)
        {
            return false;
        }
        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
			var provider = await content.ReadAsMultipartAsync();
            var modelContent = provider.Contents
                .FirstOrDefault(c => c.Headers.ContentType.MediaType == "application/json"); 
            var attachment = await modelContent.ReadAsAsync<Attachment>();
            var fileContents = provider.Contents
                .Where(c => c.Headers.ContentType.MediaType == "image/jpeg").FirstOrDefault(); // or whatever is the type of file to upload
            attachment.Content = await fileContents.ReadAsByteArrayAsync();
            return attachment;
        }
    }
	

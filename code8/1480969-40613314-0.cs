        public class JsonFormatter : JsonMediaTypeFormatter
        {
               public JsonFormatter() {
                this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                this.SerializerSettings.Formatting = Formatting.Indented;
                                      }
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders    headers, MediaTypeHeaderValue mediaType) 
    {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
                                                                   }
        }

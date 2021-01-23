    public class CustomJsonOutputFormatter : JsonOutputFormatter
    {
        public CustomJsonOutputFormatter(JsonSerializerSettings serializerSettings, ArrayPool<char> charPool)
            : base(serializerSettings, charPool)
        { }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                var @object = new ApiResponse { Data = context.Object };
                var newContext = new OutputFormatterWriteContext(context.HttpContext, context.WriterFactory, typeof(ApiResponse), @object);
                newContext.ContentType = context.ContentType;
                newContext.ContentTypeIsServerDefined = context.ContentTypeIsServerDefined;
                return base.WriteResponseBodyAsync(newContext, selectedEncoding);
            }
            return base.WriteResponseBodyAsync(context, selectedEncoding);
        }
    }

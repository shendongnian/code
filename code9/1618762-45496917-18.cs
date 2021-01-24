    public class TestModelBinderProvider : IModelBinderProvider
    {
        private readonly IList<IInputFormatter> formatters;
        private readonly IHttpRequestStreamReaderFactory readerFactory;
        public TestModelBinderProvider(IList<IInputFormatter> formatters, IHttpRequestStreamReaderFactory readerFactory)
        {
            this.formatters = formatters;
            this.readerFactory = readerFactory;
        }
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(TestModel))
                return new TestModelBinder(formatters, readerFactory);
            return null;
        }
    }

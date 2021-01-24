    public class PdfMediaTypeFormatter : MediaTypeFormatter {
        private readonly string mediaType = "application/pdf";
        Func<Type, bool> typeisIPdf = (type) => typeof(IPdf).IsAssignableFrom(type);
        Func<Type, bool> typeisIPdfCollection = (type) => typeof(IEnumerable<IPdf>).
        IsAssignableFrom(type);
        private readonly IPdfFactory report;
        public PdfMediaTypeFormatter(IPdfFactory report) {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
            MediaTypeMappings.Add(new UriPathExtensionMapping("pdf", new MediaTypeHeaderValue(mediaType)));
            this.report = report;
        }
        public override bool CanReadType(Type type) {
            return false;
        }
        public override bool CanWriteType(Type type) {
            return typeisIPdf(type) || typeisIPdfCollection(type);
        }
        public async override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext) {
            var memoryStream = report.Create(value);
            var bytes = memoryStream.ToArray();
            await writeStream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
    public interface IPdfFactory {
        MemoryStream Create(object model);
    }
    public class PdfFactory : IPdfFactory {
        private readonly IBusinessLogic _logic;
        public PdfFactory(IBusinessLogic logic) {
            this._logic = logic;
        }
        public MemoryStream Create(object model) {
            var stream = new MemoryStream();
            //...Pdf generation code
            
            //call data update
            _logic.update(model);
            return stream;
        }
    }

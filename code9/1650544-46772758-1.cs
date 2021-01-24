    public class AnyClass
    {
        private readonly IDocumentPreprocessor _documentProcessor;
        public AnyClass(Func<DocType, IDocumentPreprocessor> factoryFunc)
        {
            _documentProcessor =  factoryFunc(DocType.Doc);
        }
    }

    public interface IDocumentPreprocessorFactory
    {
        IDocumentPreprocessor CreateDocumentPreprocessor(DocType docType);
    }
    public class DocumentPreprocessorFactory : IDocumentPreprocessorFactory
    {
        private readonly Func<TxtPreprocessor> createTxtPreprocessor;
        private readonly Func<DocPreprocessor> createDocPreprocessor;
        public DocumentPreprocessorFactory(
            Func<TxtPreprocessor> createTxtPreprocessor,
            Func<DocPreprocessor> createDocPreprocessor)
        {
            this.createTxtPreprocessor = createTxtPreprocessor;
            this.createDocPreprocessor = createDocPreprocessor;
        }
        public IDocumentPreprocessor CreateDocumentPreprocessor(DocType docType)
        {
            switch (docType)
            {
                case DocType.Txt:
                    return this.createTxtPreprocessor();
                case DocType.Doc:
                    return this.createDocPreprocessor();
                default:
                    throw new...
            }
        }
    }

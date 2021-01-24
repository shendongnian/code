    public void Save(DocumentBase document)
    {
        var dispatcher = new DocumentDispatcher();
        document.Accept(dispatcher);
    }
    public abstract class DocumentBase
    {
        public abstract void Accept(IDocumentDispatcher dispatcher);
    }
    public class DocumentA : DocumentBase
    {
        public override void Accept(IDocumentDispatcher dispatcher)
        {
            dispatcher.Dispatch(this);
        }
    }
    public class DocumentB : DocumentBase
    {
        public override void Accept(IDocumentDispatcher dispatcher)
        {
            dispatcher.Dispatch(this);
        }
    }
    public interface IDocumentDispatcher
    {
        void Dispatch(DocumentA document);
        void Dispatch(DocumentB document);
    }
    public class DocumentDispatcher : IDocumentDispatcher
    {
        public void Dispatch(DocumentA document)
        {
            this.RepositoryFactory.Get<DocumentA>().Update(document);
        }
        public void Dispatch(DocumentB document)
        {
            this.RepositoryFactory.Get<DocumentB>().Update(document);
        }
    }

    public void Save(DocumentBase document)
    {
        var dispatcher = new DocumentDispatcher();
        dispatcher.Dispatch((dynamic)document);
    }
    public class DocumentDispatcher : IDocumentDispatcher
    {
        public void Dispatch<T>(T document)
        {
            this.RepositoryFactory.Get<T>().Update(document);
        }
    }

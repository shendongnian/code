    abstract class Container<T>
        where T : ViewDocumentDto, new()
    {
        public abstract T ToViewDocument(XmlEntity entity, DocKey documentKey);
    }
    
    class SpecificContainer : Container<SpecificViewDocumentDto>
    {
        public override SpecificViewDocumentDto ToViewDocument(XmlEntity entity, DocKey documentKey)
        {
        }
    }

        public abstract class BaseHyperLink<THyperLink> : Entity<int>
            where THyperLink : BaseHyperLink<THyperLink>
        {
            protected BaseHyperLink(int? id, Uri hyperLink, ContentType contentType, DocumentType documentType)
                : base(id)
            {
                this.HyperLink = hyperLink;
                this.ContentType = contentType;
                this.DocumentType = documentType;
            }
            
            public Uri HyperLink { get; }
            public ContentType ContentType { get; }
            public DocumentType DocumentType { get; }
            
            public abstract THyperLink WithContentType(ContentType contentType);
        }

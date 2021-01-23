        public sealed class SharedHyperLink : BaseHyperLink<SharedHyperLink>
        {
            public SharedHyperLink(int? id, Uri hyperLink, ContentType contentType, DocumentType documentType)
                : base(id, hyperLink, contentType, documentType)
            {
            }
            
            public override SharedHyperLink WithContentType(ContentType contentType)
            {
                return new SharedHyperLink(this.Id, contentType, this.DocumentType);
            }
        }

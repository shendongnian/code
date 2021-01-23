        public sealed class MarkedHyperLink : BaseHyperLink<MarkedHyperLink>
        {
            public MarkedHyperLink(int? id, Uri hyperLink, ContentType contentType, DocumentType documentType, Mark mark)
                : base(id, hyperLink, contentType, documentType)
            {
                this.Mark = mark;
            }
            public Mark Mark { get; }
            
            public override MarkedHyperLink WithContentType(ContentType contentType)
            {
                return new MarkedHyperLink(this.Id, contentType, this.DocumentType, this.Mark);
            }
        }

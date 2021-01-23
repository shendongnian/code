    class StripStringHandler : BaseRdfHandler, IWrappingRdfHandler
    {
        protected override bool HandleTripleInternal(Triple t)
        {
            if (t.Object is ILiteralNode)
            {
                var literal = t.Object as ILiteralNode;
    
                if (literal.DataType != null && (literal.DataType.AbsoluteUri == "http://www.w3.org/2001/XMLSchema#string" || literal.DataType.AbsoluteUri == "http://www.w3.org/2001/XMLSchema#langString"))
                {
                    var simpleLiteral = this.CreateLiteralNode(literal.Value, literal.Language);
    
                    t = new Triple(t.Subject, t.Predicate, simpleLiteral);
                }
            }
    
            return this.handler.HandleTriple(t);
        }
    
        private IRdfHandler handler;
    
        public StripStringHandler(IRdfHandler handler) : base(handler)
        {
            this.handler = handler;
        }
    
        public IEnumerable<IRdfHandler> InnerHandlers
        {
            get
            {
                return this.handler.AsEnumerable();
            }
        }
    
        protected override void StartRdfInternal()
        {
            this.handler.StartRdf();
        }
    
        protected override void EndRdfInternal(bool ok)
        {
            this.handler.EndRdf(ok);
        }
    
        protected override bool HandleBaseUriInternal(Uri baseUri)
        {
            return this.handler.HandleBaseUri(baseUri);
        }
    
        protected override bool HandleNamespaceInternal(string prefix, Uri namespaceUri)
        {
            return this.handler.HandleNamespace(prefix, namespaceUri);
        }
    
        public override bool AcceptsAll
        {
            get
            {
                return this.handler.AcceptsAll;
            }
        }
    }

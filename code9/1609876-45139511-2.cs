    public class XObjectsProvider
    {
        private Loader _loader;
        private Transformer _transformer;
        public XObjectsProvider(Loader loader, Transformer transformer)
        {
            _loader = loader;
            _transformer = transformer;
        }
        public XObjects Get()
        {
            var yObjects = _loader.GetYObjects();
            return transformer.Transform(yObjects);
        }
    }

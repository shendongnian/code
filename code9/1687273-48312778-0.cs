    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public IHttpControllerSelector PreviousSelector { get; set; }
        public CustomControllerSelector(HttpConfiguration configuration):base(configuration)
        {
            _config = configuration;
        }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var uriSegments = request.RequestUri.Segments;
            var system = uriSegments[2];
            request.RequestUri = new System.Uri(request.RequestUri.AbsoluteUri.Replace(system, ""));
            var controllerDescriptor = PreviousSelector.SelectController(request);
            return controllerDescriptor;
        }
    }

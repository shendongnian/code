    class MethodConstraintedRouteAttribute 
        : RouteFactoryAttribute, IActionHttpMethodProvider, IHttpRouteInfoProvider {
        public MethodConstraintedRouteAttribute(string template, HttpMethod method)
            : base(template) {
            HttpMethods = new Collection<HttpMethod>(){
                method
            };
        }
        public Collection<HttpMethod> HttpMethods { get; private set; }
        public override IDictionary<string, object> Constraints {
            get {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("method", new HttpMethodConstraint(HttpMethods.ToArray()));
                return constraints;
            }
        }
    }

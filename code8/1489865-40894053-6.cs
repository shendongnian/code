    class MethodConstraintedRouteAttribute : RouteFactoryAttribute, IActionHttpMethodProvider {
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
                constraints.Add("method", new MethodConstraint(HttpMethods));
                return constraints;
            }
        }
    }
    class MethodConstraint : IHttpRouteConstraint {
        public Collection<HttpMethod> Methods { get; private set; }
        public MethodConstraint(Collection<HttpMethod> methods) {
            Methods = methods;
        }
        public bool Match(HttpRequestMessage request,
                          IHttpRoute route,
                          string parameterName,
                          IDictionary<string, object> values,
                          HttpRouteDirection routeDirection) {
            return Methods.Contains(request.Method);
        }
    }

    class HttpGetAttribute : MethodConstraintedRouteAttribute {
        public HttpGetAttribute(string template) : base(template, HttpMethod.Get) { }
    }
    class HttpPostAttribute : MethodConstraintedRouteAttribute {
        public HttpPostAttribute(string template) : base(template, HttpMethod.Post) { }
    }

    class HttpSessionStateMock : HttpSessionStateBase {
        private readonly IDictionary<string, object> objects = new Dictionary<string, object>();
        public HttpSessionStateMock(IDictionary<string, object> objects = null) {
            this.objects = objects ?? new Dictionary<string, object>();
        }
        public override object this[string name] {
            get { return (objects.ContainsKey(name)) ? objects[name] : null; }
            set { objects[name] = value; }
        }
    }

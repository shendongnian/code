    public class SwaggerDocument
    {
        public string host { get; set; }
        public IDictionary<string, IDictionary<string, PathItem>> paths;
    }
    public class PathItem
    {
        public string summary { get; set; }
        public string operationId { get; set; }
        public object parameters { get; set; }
        public object responses { get; set; }
    }

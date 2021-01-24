    public string Body { get; set; }
    public IDictionary<string, string> Headers { get; set; }
    public string HttpMethod { get; set; }
    public bool IsBase64Encoded { get; set; }
    public string Path { get; set; }
    public IDictionary<string, string> PathParameters { get; set; }
    public IDictionary<string, string> QueryStringParameters { get; set; }
    public ProxyRequestContext RequestContext { get; set; }
    public string Resource { get; set; }
    public IDictionary<string, string> StageVariables { get; set; }

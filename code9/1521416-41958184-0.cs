    /// <summary>
    /// Custom handler to allow pretty print json results.
    /// </summary>
    public class PrettyPrintJsonHandler : DelegatingHandler {
        const string prettyPrintConstant = "pretty";
        MediaTypeHeaderValue contentType = MediaTypeHeaderValue.Parse("application/json;charset=utf-8");
        private System.Web.Http.HttpConfiguration httpConfig;
        /// <summary>
        /// Initializes a new instance of the <seealso cref="PrettyPrintJsonHandler"/> class with an HTTP Configuration.
        /// </summary>
        /// <param name="config"></param>
        public PrettyPrintJsonHandler(System.Web.Http.HttpConfiguration config) {
            this.httpConfig = config;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) {
            var canPrettyPrint = checkQuery(request.RequestUri.Query);
            var jsonFormatter = httpConfig.Formatters.JsonFormatter;
            jsonFormatter.Indent = canPrettyPrint;
            var response = await base.SendAsync(request, cancellationToken);
            
            if (canPrettyPrint && response.Content != null) {
                response.Content.Headers.ContentType = contentType;
            }
            
            return response;
        }
        private bool checkQuery(string queryString) {
            var canPrettyPrint = false;
            if (!string.IsNullOrWhiteSpace(queryString)) {
                var prettyPrint = QueryString.Parse(queryString)[prettyPrintConstant];
                canPrettyPrint = !string.IsNullOrWhiteSpace(prettyPrint) && Boolean.TryParse(prettyPrint, out canPrettyPrint) && canPrettyPrint;
            }
            return canPrettyPrint;
        }
    }

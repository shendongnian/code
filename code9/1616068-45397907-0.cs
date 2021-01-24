    public static class ValidHeaders {
        public static readonly IList<string> List = new ReadOnlyCollection<string>(new List<string>
        {
            "Content-Type",
            "DataServiceVersion",
            "MinDataServiceVersion",
            "Accept",
            "If-Match",
            "If-None-Match",
            "Prefer"
        });
        public static IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetValidHeaders(this HttpRequestMessage request) {
            var validHeaders = request.Headers.Where(header => ValidHeaders.List.Contains(header.Key));
            return validHeaders;
        }
    }

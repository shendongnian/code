    [JsonConverter(typeof(PagedResultsConverter))]
    public class PagedResults<T>
    {
        public IEnumerable<T> Results { get; set; }
    }

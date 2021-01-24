    public class Rootobject
    {
        public Result[] result { get; set; }
        public int resultCount { get; set; }
        public object pagedResultsCookie { get; set; }
        public string totalPagedResultsPolicy { get; set; }
        public int totalPagedResults { get; set; }
        public int remainingPagedResults { get; set; }
    }
    public class Result
    {
        public string _id { get; set; }
        public string _rev { get; set; }
        public string[] ahaMemberGroup { get; set; }
    }

    public class BookmakerUrl
    {
        public string link { get; set; }
        public string name { get; set; }
    }
    public class RootObject
    {
        public int page { get; set; }
        public Dictionary<string, List<BookmakerUrl>> bookmaker_urls { get; set; }
        public string block_service_id { get; set; }
        public int round_id { get; set; }
        public bool outgroup { get; set; }
        public int view { get; set; }
        public int competition_id { get; set; }
    }

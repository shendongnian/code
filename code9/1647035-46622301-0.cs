    var rootObj = JsonConvert.DeserializeObject<SOTest.RootObject>(json);
    foreach(var item in rootObj.albums.items)
    {
        Console.WriteLine(item.id);
    }
-----
    public class SOTest
    {
        public class ExternalUrls
        {
            public string spotify { get; set; }
        }
        public class Artist
        {
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }
        public class Image
        {
            public int height { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }
        public class Item
        {
            public string album_type { get; set; }
            public List<Artist> artists { get; set; }
            public List<string> available_markets { get; set; }
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }
        public class Albums
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int limit { get; set; }
            public string next { get; set; }
            public int offset { get; set; }
            public object previous { get; set; }
            public int total { get; set; }
        }
        public class RootObject
        {
            public Albums albums { get; set; }
        }
    }

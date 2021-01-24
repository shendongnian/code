    public class AlbumSearchResponse
        {
            public string error { get; set; }
            public int iTotalRecords { get; set; }
            public int iTotalDisplayRecords { get; set; }
            public int sEcho { get; set; }
            public List<List<string>> aaData { get; set; }
        }

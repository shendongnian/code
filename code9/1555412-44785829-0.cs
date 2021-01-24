    //Let's assume this is your model....
    public class RequestData
    {
        public int RowCount { get; set; }
        public int Current { get; set; }
        public string Search { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public int TotalItems { get; set; }
    }

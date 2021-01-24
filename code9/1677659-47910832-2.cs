    interface IFiles
    {
        string myField { get; set; }
        int myHash { get; set; }
    }
    class MediaFiles : IFiles
    {
        public string myField { get; set; }
        public int myHash { get; set; }
    }

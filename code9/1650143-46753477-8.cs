    public class ShirtData
    {
        public string pic_path { get; set; }
        public string name { get; set; }
        public ShirtData(string path, string theName)
        {
            pic_path = path;
            name = theName;
        }
    }

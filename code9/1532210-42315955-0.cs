    public class File
    {
        public string file { get; set; }
    }
    public class RootObject
    {
        public string accountName { get; set; }
        public List<File> files { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = ""; // load from remote service or from a local file
            var obj = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
        }
    }

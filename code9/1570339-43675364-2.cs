    public class Program
    {
        public static void Main()
        {
            var fileNames = new[] { "SMA#1#1", "SMA#1#2", "SMA#1#3", "SMA#2#1", "SMA#2#3" };
            var files = (from fileName in fileNames select fileName.Split('#') into parts let name = parts[0] let page = Int32.Parse(parts[1]) let version = Int32.Parse(parts[2]) select new MyFile(name, page, version)).ToList();
            var grouped = files.GroupBy(x => x.Page).ToList();
            foreach (var group in grouped)
            {
                var ordered = group.OrderByDescending(x => x.Version);
                Console.WriteLine($"Page {group.Key} highest version: {ordered.First().Version}");
            }
        }
    }
    
    public class MyFile
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int Version { get; set; }
    
        public MyFile(string name, int page, int version)
        {
            Name = name;
            Page = page;
            Version = version;
        }
    }

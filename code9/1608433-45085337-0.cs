    static class Program
    {
        static Dictionary<string, object> ObjToDic(object o)
        {
            return o.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(o));
        }
        static void Main(string[] args)
        {
            var fileNames = Directory.EnumerateFiles("c:\\windows");
            foreach (string name in fileNames)
            {
                Console.WriteLine("==========================================");
                FileInfo fi = new FileInfo(name);
                var propDict = ObjToDic(fi); // <== Here we convert FileInfo to dictionary
                foreach (var item in propDict.AsEnumerable())
                {
                    Console.WriteLine(string.Format("{0}: {1}", item.Key, item.Value.ToString()));
                }
            }
        }
    }

    class Program
    {
        static string RetreiveFileContent(string filename)
        {
            if(!File.Exists(filename))
                return default(string);
            return File.ReadAllText(filename);
        }
        static void Main(string[] args)
        {
            var textFileCache = new MyCache<string, string>(TimeSpan.FromMinutes(2), RetreiveFileContent);
            var content = textFileCache["helloworld.txt"];
            // sometimes you need to cleanup old data.
            textFileCache.Cleanup();
        }
    }

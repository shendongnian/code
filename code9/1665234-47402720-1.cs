    class Program
    {
        static void Main()
        {
            var targetDir = ConfigurationManager.AppSettings["inDir"];
            var outputFile = ConfigurationManager.AppSettings["outFile"];
            foreach (var fileName in Directory.EnumerateFiles(targetDir, "*", 
                SearchOption.AllDirectories))
            {
                ProcessFile(fileName, outputFile);
            }
        }
        public static void ProcessFile(string inputFile, string outputFile)
        {
            var lines = File.ReadLines(inputFile)
                .Where(x => x[0] != '#')
                .Select(line => line.Split(' '))
                .Where(fields =>
                    fields[8] != "-" // and other filtering
                )
                .Select(f => string.Join(
                    " ", f[0], f[8].ToLower().Replace("some_value", ""),
                    true || false ? "1" : "0"))
                .Distinct();
            File.AppendAllLines(outputFile, lines);
        }
    }

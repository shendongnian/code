    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"c:\temp\file.txt";
            var lines = File.ReadAllLines(filePath);
            var oks = lines.Count(s => s.EndsWith("OK"));
            var ngs = lines.Count(s => s.EndsWith("NG"));
            Console.WriteLine("OKs: {0}, NGs {1}",oks,ngs);
        }
    }

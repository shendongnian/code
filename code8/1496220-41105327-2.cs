    class Program
    {
        static void Main(string[] args)
        {
            string source = @"c:\Users\florian\Desktop\mytestfile.fil";
            string destination = "p";
            using (FileStream SourceStream = File.Open(source, FileMode.Open))
            {
                using (FileStream DestinationStream = File.Create(destination + source.Substring(source.LastIndexOf('\\'))))
                {
                    SourceStream.CopyTo(DestinationStream);
                }
            }
        }
    }

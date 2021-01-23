    class Program
    {
        static void Main(string[] args)
        {
            CopyAsync(@"c:\Users\florian\Desktop\mytestfile.fil", "p:").Wait();
        }
        private static async Task CopyAsync(string source, string destination)
        {
            using (FileStream SourceStream = File.Open(source, FileMode.Open))
            {
                using (FileStream DestinationStream = File.Create(destination + source.Substring(source.LastIndexOf('\\'))))
                {
                    await SourceStream.CopyToAsync(DestinationStream);
                }
            }
        }
    }

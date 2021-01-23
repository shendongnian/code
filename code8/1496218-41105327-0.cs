    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread thread = new System.Threading.Thread(()=> Copy(@"c:\Users\florian\Desktop\mytestfile.fil", "p:"));
            thread.Start();
        }
        private static void Copy(string source, string destination)
        {
            using (FileStream SourceStream = File.Open(source, FileMode.Open))
            {
                using (FileStream DestinationStream = File.Create(destination + source.Substring(source.LastIndexOf('\\'))))
                {
                    SourceStream.CopyToAsync(DestinationStream);
                }
            }
        }
    }

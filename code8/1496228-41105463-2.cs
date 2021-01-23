    static void Main(string[] args)
    {
        var t = Task.Run(() => Copy(@"c:\Users\florian\Desktop\mytestfile.fil", "p:"));
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

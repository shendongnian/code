        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }
        static async void MainAsync(string[] args)
        {
            var t = Task.Run(() => Copy(@"c:\Users\florian\Desktop\mytestfile.fil", "p:"));
            Console.WriteLine("doing more stuff while copying");
            await t;
            Console.WriteLine("Finished !");
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

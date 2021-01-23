        class Program
        {
            private static void Main(string[] args)
            {
                var source = new CancellationTokenSource();
                Console.CancelKeyPress += (s, e) =>
                {
                    e.Cancel = true;
                    source.Cancel();
                };
    
            try
            {
                MainAsync(args, source.Token).GetAwaiter().GetResult();
                return;
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    
        static async Task MainAsync(string[] args, CancellationToken token)
        {
            var t = Task.Run(() => Copy(@"c:\test.txt", @"c:\dest\"));
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
                    SourceStream.CopyTo(DestinationStream);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // Display some error message here
                return;
            }
            string[] urls = File.ReadAllLines(args[0]);
            foreach (var url in urls)
            {
                DownloadUrl(url);
            }
        }
        private static void DownloadUrl(string url)
        {
            // Put most of your current code in here.
            // You need to infer the name of the file to save - 
            // consider using new Uri(url), then Uri.LocalPath
        }
    }

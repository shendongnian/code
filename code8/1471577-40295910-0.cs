    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string address = "https://www.gravatar.com/avatar/957c8334a5950ba301f66662b36da7d1";
            // Save the file to desktop for debugging
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = desktop + "\\gravatar.jpg";
            client.DownloadFile(address, fileName);
            Console.ReadLine();
        }
    }

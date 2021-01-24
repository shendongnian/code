    private static Random _random = new Random();
    static void Main(string[] args)
    {
        using (var webCon = new WebClient())
        {
            var webData = webCon.DownloadString("http://stackoverflow.com/questions/43253136/");
            var lines = webData.Split('\n');
            var myRandomLine = lines[_random.Next(0, webData.Length - 1)];
        }
    }

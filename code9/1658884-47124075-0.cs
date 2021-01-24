    static void Main(string[] args)
    {
        var Usernames = File.ReadAllLines(@"C:\Users\Hasan\Desktop\Usernames.txt");
        Parallel.ForEach(Usernames, Username =>
        {
            try
            {
                using (WebClient WebClient = new WebClient())
                {
                    WebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36");
                    string response = WebClient.DownloadString("https://www.habbo.com/api/public/users?name=" + Username);
            }
            catch (Exception ex)
            {
                if ( ex is WebException and (ex.Response as HttpWebResponse)?.StatusCode.ToString() ?? ex.Status.ToString() == "404" )
                {
                    Console.WriteLine("Possibly Free : " + Username);
                }
                //Console.WriteLine("Error on Username : " + Username);
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        });
    } 

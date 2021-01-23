    static void Main(string[] args)
        {
            try
            {
                var urlAddress = "http://mywebsite.com/msexceldoc.xlsx";
                using (var client = new WebClient())
                {
                   client.Credentials = new NetworkCredential("UserName", "Password");
                    client.DownloadFileAsync(new Uri(urlAddress), @"D:\1.xlsx");
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            }
            catch (Exception ex)
            {
            }
        Console.ReadLine();
        }
    public static void Completed(object o, AsyncCompletedEventArgs args)
    {
        Console.WriteLine("Completed");
    }

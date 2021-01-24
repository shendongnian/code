    using (WebClient client = new WebClient ()) // WebClient class inherits IDisposable
    {
        string htmlCode = client.DownloadString("myLink");
        //...
    }

    string RefURL = "https://www.whatismyip.com/";
    try
    {
        string myProxyIP = "119.81.197.124"; //check this is still available
        int myPort = 3128;
        string userId; //leave it blank
        string password;
        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = web.Load(RefURL.ToString(), myProxyIP, myPort, userId, password);
        Console.WriteLine(doc.DocumentNode.InnerHtml);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

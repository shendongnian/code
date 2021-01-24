    string RefURL = "https://www.whatismyip.com/";
    string myProxyIP = "119.81.197.124"; //check this is still available
    int myPort = 3128;
    string userId = string.Empty; //leave it blank
    string password = string.Empty;
    try
    {
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(RefURL.ToString(), myProxyIP, myPort, userId, password);
        Console.WriteLine(doc.DocumentNode.InnerHtml);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

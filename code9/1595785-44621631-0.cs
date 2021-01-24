    WebRequest request = HttpWebRequest.Create("your uri");
    WebResponse response = await request.GetResponseAsync();
    Stream stream = response.GetResponseStream();
    var result = "";
    using (StreamReader sr = new StreamReader(stream))
    {
        result = sr.ReadToEnd();
    }
    HtmlDocument MobileDocument = new HtmlDocument();
    MobileDocument.LoadHtml(result);
    var nodes = MobileDocument.DocumentNode.SelectNodes("//id('ContentHolderMain_ContentHolderMainContent_ContentHolderMainContent_pnlDaily')/x:div/x:ol/x:li[3]/x:ul]");
    foreach (var item in nodes)
    { 
     ...
    }

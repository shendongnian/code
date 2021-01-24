    // your string variable containing HTML
    String html = ...
    
    HtmlDocument document = new HtmlDocument();
    document.LoadHtml(html);
    
    foreach (HtmlParseError error in document.ParseErrors)
    {
        Console.WriteLine("ERROR: " + error.Code.ToString());
        Console.WriteLine(error.Reason);
        Console.WriteLine();
    }

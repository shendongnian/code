    using HtmlAgilityPack;
    using System.Web.Services;
    [WebMethod(EnableSession = true)]
    public static string MethodToPassResult(string sendData)
    {
        String currentHtml = HttpUtility.HtmlDecode(sendData);
        byte[] byteArray = Encoding.UTF8.GetBytes(currentHtml);
        MemoryStream stream = new MemoryStream(byteArray);
        HtmlDocument html = new HtmlDocument();
        html.Load(stream);
        HtmlDocument HTMLDocument = html;
        HtmlDocument HTMLDocumentDiv = new HtmlDocument();
        //Do something here such as iterate through all divs
        var itemList = HTMLDocument.DocumentNode.SelectNodes("//div")
                  .Select(p => p)
                  .ToList();
        return "result string from code behind";
    }
    

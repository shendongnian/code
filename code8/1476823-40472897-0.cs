    var response = (HttpWebResponse)request.GetResponse();
    var stream = response.GetResponseStream();
    HtmlDocument doc = new HtmlDocument();
    doc.Load(stream);
    foreach (HtmlNode serviceOkNode in doc.DocumentNode.SelectNodes("//table[@class]/tr/td[@class = 'serviceOK']"))
    {
        HtmlNode serviceNameNode = serviceOkNode.PreviousSibling;
        var value = serviceOkNode.InnerText;
        var name = serviceNameNode.InnerText;
    }

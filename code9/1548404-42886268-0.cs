    HttpClient http = new HttpClient();
    
    //I have put Ebay.com. you could use any.
    var response = await http.GetByteArrayAsync("ebay.com"); 
    String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
    source = WebUtility.HtmlDecode(source);
    HtmlDocument Nodes = new HtmlDocument();
    Nodes.LoadHtml(source);

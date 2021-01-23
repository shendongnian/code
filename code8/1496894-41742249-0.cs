    var plainContent = Regex.Replace(wallItem.content, @"^?\[.*", ""); 
    
    var cleanedContent = plainContent;
    
    //The Webview Source HTML
    HtmlWBS.Html = cleanedContent;

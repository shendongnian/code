    var html = @"
    <div>
    <strong>First name</strong><em>italic</em>: Fake<br>
    <strong>Bold</strong> <a href='#'>hyperlink</a><br>.
    <strong>bold</strong>
    <strong>bold</strong> <br>
    text
    </div>
    
    <div>
    <strong>Title</strong>: Mr<BR>
    <strong>First name</strong>: Fake<br>
    <strong>Surname</strong>: Guy<br>
    </div>";
    
    var document = new HtmlDocument();
    document.LoadHtml(html);
    // 1. <strong>
    var strong = document.DocumentNode.SelectNodes("//strong");
    if (strong != null)
    {
        foreach (var node in strong.Where(
            // 2. followed by non-empty text node
            x => x.NextSibling is HtmlTextNode
            && !string.IsNullOrEmpty(x.NextSibling.InnerText.Trim())
            // 3. followed by <br>
            && x.NextSibling.NextSibling is HtmlNode
            && x.NextSibling.NextSibling.Name.ToLower() == "br"))
        {
            Console.WriteLine("{0} {1}", node.InnerText, node.NextSibling.InnerText);
        }
    }

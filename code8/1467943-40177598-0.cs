    var Webget = new HtmlWeb();
    var builder = new StringBuilder();
    foreach (string line in File.ReadLines("c:\\test.txt"))
    {
        var doc = Webget.Load(line);
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id='title-article']"))
        {
            builder.AppendFormat("{0}\r\n", node.ChildNodes[0].InnerHtml);
            break;
        }
    }
    memoEdit1.Text = builder.ToString();
    

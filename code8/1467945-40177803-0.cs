    StringBuilder builder = new StringBuilder();
    var Webget = new HtmlWeb();
    foreach (string line in File.ReadLines("c:\\test.txt"))
    {
        var doc = Webget.Load(line);
        builder.AppendLine(doc.DocumentNode.SelectSingleNode("//*[@id='title-article']").InnerHtml);
    }
    memoEdit1.Text = builder.ToString();

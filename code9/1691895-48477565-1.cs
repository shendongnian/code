    HtmlDocument document = new HtmlDocument();
    document.LoadHtml(rawdata);
    StringBuilder sb = new StringBuilder();
    foreach (HtmlNode paragraph in document.DocumentNode.SelectNodes("//p"))
    {
        sb.Append(paragraph.InnerText);
    }
    valuetxt.Text = sb.ToString();

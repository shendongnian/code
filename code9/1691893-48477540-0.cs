    string content = "";
    foreach (HtmlNode paragraph in document.DocumentNode.SelectNodes("//p"))
    {
        content += paragraph.InnerText;
    }
    valuetxt.Text = content;

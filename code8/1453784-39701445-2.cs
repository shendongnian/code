    string html = "<li><ol>  **Text/List**  </li></ol><p><br></p><br><br>";
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var brToRemove = doc.DocumentNode.Descendants().Reverse().TakeWhile(n => n.Name == "br");
    foreach (HtmlNode node in brToRemove)
        node.Remove();
    using (StringWriter writer = new StringWriter())
    {
        doc.Save(writer);
        string result = writer.ToString();
    }

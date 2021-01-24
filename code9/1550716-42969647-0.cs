    var doc1 = new HtmlAgilityPack.HtmlDocument();
        doc1.LoadHtml("<p class=\"cs40314EBF\"><span class=\"cs1B16EEB5\">This is an ordinary text.</span></p>");
        foreach (var item in doc1.DocumentNode.Descendants())
        {
            if (item.Name == "span")
            {
                HtmlNode b = doc.CreateElement("b");
                b.InnerHtml = item.InnerText;
                item.ParentNode.AppendChild(b);
                item.Remove();
            }
        }

      var doc = new HtmlDocument();
      doc.LoadHtml(rawHtml);
      var first = doc.DocumentNode.Descendants()
            .Where(_ => _.Name == "a")
            .OfType<HtmlNode>()
            .Select(_ => _.Attributes["href"])
            .Select(_ => 
            {
                try
                {
                    DateTime.TryParseExact(_.Value, "yyyyMMdd/", null, DateTimeStyles.None, out var result);
                    return (DateTime?)result;
                }
                catch
                {
                    return null;
                }
            })
            .Where(_=> _.HasValue)
            .OrderByDescending(_ => _.Value)
            .FirstOrDefault();

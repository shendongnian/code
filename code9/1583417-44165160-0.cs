            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml("<p><b>Focus on the Family Great Stories collection</b><b>—</b></p>");
            foreach (var item in doc.DocumentNode.Descendants("p").ToList())
            {
                if (item.HasChildNodes)
                {
                    var grouped = item.ChildNodes.GroupBy(_ => _.Name);
                    HtmlNode newNode = doc.CreateElement(grouped.FirstOrDefault().Key);
                    foreach (var bNode in grouped.FirstOrDefault())
                    {
                        newNode.InnerHtml += bNode.InnerText;
                    }
                    item.InnerHtml = newNode.OuterHtml;
                }
            }

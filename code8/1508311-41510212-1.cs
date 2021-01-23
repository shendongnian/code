    var table3 = doc.DocumentNode.Descendants().FirstOrDefault(x =>
                {
                    if (x.NodeType == HtmlAgilityPack.HtmlNodeType.Element)
                    {
                        if (x.PreviousSibling?.NodeType == HtmlAgilityPack.HtmlNodeType.Text)
                        {
                            return x.PreviousSibling.PreviousSibling?.Name == "h3" && x.PreviousSibling.PreviousSibling?.InnerText == "test";
                        } else
                        {
                            return x.PreviousSibling?.Name == "h3" && x.PreviousSibling?.InnerText == "test";
                        }
                    }
                    return false;
                });

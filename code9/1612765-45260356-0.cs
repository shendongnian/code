                var parentnode = node.ParentNode.ParentNode.ParentNode.FirstChild.NextSibling;
                var nameNode = parentnode.FirstChild;
                Links l = new Links();
                l.Name = ParseHtmlContainingText(nameNode.InnerText);
                l.Link = node.GetAttributeValue("href", "");

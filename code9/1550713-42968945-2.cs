                if (item.Name == "span")
                {
                    HtmlNode div = doc.CreateElement("b");
                    div.InnerHtml = "Hello world";
                    item.AppendChild(div);
                    doc.Save(yourfilepath);
                }
            

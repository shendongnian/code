           var child = htmlDoc.DocumentNode.SelectNodes("//span[@class='fb']")
                               .FirstOrDefault();
            if (child != null)
            {
                var parent = child.ParentNode;
                parent.RemoveChild(child);
                var innerText = parent.InnerText;              
            }

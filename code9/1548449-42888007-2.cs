           var child = htmlDoc.DocumentNode.SelectNodes("//span[@class='fb']")
                               .FirstOrDefault();
            if (child != null)
            {
                var parent = child.ParentNode;
                parent.Remove(child);
                var innerText = parent.InnerText;              
            }

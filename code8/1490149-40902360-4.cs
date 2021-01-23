    public static class HtmlAgilityPackExtensions
    {
        public static HtmlNode Closest(this HtmlNode node, string jQuerySelector)
        {
            if (node == null) return null;
            string tagName = "", id = "";
            var classes = new List<string>();
    
            if (jQuerySelector.Contains("."))
            {
                var parts = jQuerySelector.Split('.');
    
                if (!string.IsNullOrWhiteSpace(parts[0]))
                {
                    tagName = parts[0];
                }
    
                for (int i = 1; i < parts.Length; i++)
                {
                    classes.Add(parts[i]);
                }
            }
    
            if (jQuerySelector.Contains("#"))
            {
                var parts = jQuerySelector.Split('#');
    
                if (!string.IsNullOrWhiteSpace(parts[0]))
                {
                    tagName = parts[0];
                }
    
                id = parts[1];
            }
            if (string.IsNullOrWhiteSpace(tagName) && string.IsNullOrWhiteSpace(id) && classes.Count == 0)
            {
               tagName = jQuerySelector;
            }
    
            HtmlNode closestParent = null;
    
            while (node.ParentNode != null && closestParent == null)
            {
                var isClosest = true;
                node = node.ParentNode;
    
                if (!string.IsNullOrWhiteSpace(tagName))
                {
                    isClosest = node.Name == tagName;
                }
    
                if (isClosest && !string.IsNullOrWhiteSpace(id))
                {
                    isClosest = node.Id == id;
                }
    
                if (isClosest && classes.Count > 0)
                {
                    var classNames = node.GetAttributeValue("class", "");
                    if (!string.IsNullOrWhiteSpace(classNames))
                    {
                        foreach (string c in classes)
                        {
                            isClosest = classNames.Contains(c);
                            if (!isClosest) break;
                        }
                    }
                }
    
                if (isClosest)
                {
                    closestParent = node;
                }
            }
    
            return closestParent;
        }
    }

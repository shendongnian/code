    internal static class Utils
    {
        internal static List<HtmlElement> GetElementsByClassName(this HtmlElement doc, string className = "")
        {
            var list = new List<HtmlElement>();
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    list.Add(e);
            return list;
        }
    }

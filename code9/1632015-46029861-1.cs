    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString HashLink(this HtmlHelper htmlHelper, string text, string className = "")
        {
            var anchor = new TagBuilder("a");
            anchor.InnerHtml = text;
            anchor.Attributes.Add("href", "#");
            
            if(!string.IsNullOrWhiteSpace(className))
            {
                anchor.AddCssClass(className);
            }
            return MvcHtmlString.Create(anchor.ToString());
        }
    }

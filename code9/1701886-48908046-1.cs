    public sealed class MvcHtmlStringConverter : ITypeConverter<string, MvcHtmlString>
    {
        public MvcHtmlString Convert(string source, MvcHtmlString destination, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                if (source.IndexOf("~") > -1)
                {
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(source);
                    CleanAttributes(document.DocumentNode.SelectNodes("//img[starts-with(@src, '~')]"), "src");
                    CleanAttributes(document.DocumentNode.SelectNodes("//a[starts-with(@href, '~')]"), "href");
                    destination = MvcHtmlString.Create(document.DocumentNode.OuterHtml);
                }
                else
                {
                    destination = MvcHtmlString.Create(source);
                }
            }
            else
            {
                destination = MvcHtmlString.Empty;
            }
            return destination;
        }
        private static void CleanAttributes(HtmlNodeCollection htmlNodeCollection, string attribute)
        {
            if (htmlNodeCollection != null && htmlNodeCollection.Count > 0)
            {
                foreach (HtmlNode node in htmlNodeCollection)
                {
                    string attributeValue = node.Attributes[attribute].Value;
                    if (attributeValue.StartsWith("~"))
                    {
                        node.SetAttributeValue(attribute, VirtualPathUtility.ToAbsolute(attributeValue.ToLower()));
                    }
                }
            }
        }
    }

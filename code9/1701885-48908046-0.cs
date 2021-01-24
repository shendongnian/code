    public sealed class MvcHtmlStringResolver : IMemberValueResolver<object, object, string, MvcHtmlString>
    {
        public MvcHtmlString Resolve(object source, object destination, string sourceMember, MvcHtmlString destMember, ResolutionContext context)
        {
            if (source == null || sourceMember == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (sourceMember.IndexOf("~") > -1)
            {
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(sourceMember);
                CleanAttributes(document.DocumentNode.SelectNodes("//img[starts-with(@src, '~')]"), "src");
                CleanAttributes(document.DocumentNode.SelectNodes("//a[starts-with(@href, '~')]"), "href");
                return MvcHtmlString.Create(document.DocumentNode.OuterHtml);
            }
            return MvcHtmlString.Empty;
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

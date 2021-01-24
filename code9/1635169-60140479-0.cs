     [HtmlTargetElement("HyperLink")]
    public class HyperLinkTagHelper : TagHelper
    {
        #region Proprietes
        public string AspAction { get; set; }
        public string AspController { get; set; }
        public Method Method { get; set; } = Method.Get;
        public string Class { get; set; }
        public string Style { get; set; }
        private IDictionary<string, string> _routeValues;
        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get => _routeValues ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            set => _routeValues = value;
        }
        #endregion
        #region Injectable
        private readonly IUrlHelper _urlHelper;
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="urlHelper"></param>
        public HyperLinkTagHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        /// <summary>
        /// Render output 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            var linkName = (await output.GetChildContentAsync()).GetContent();
            var builder = new StringBuilder();
            var method = Method.ToString().ToLower();
            var link = _urlHelper.Action(AspAction, AspController);
            builder.AppendFormat("<form method='{0}' role='form' action='{1}'>", method, link);
            foreach (var (key, value) in _routeValues)
            {
                builder.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", key, value);
            }
            builder.AppendFormat("<input type='submit' value='{0}' class='{1}' style='{2}'/>", linkName, Class, Style);
            builder.Append("</form>");
            output.Content.SetHtmlContent(builder.ToString());
        }
    }

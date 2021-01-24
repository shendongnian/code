    [HtmlTargetElement("helplink")]
    public class RazorTagHelper : TagHelper
    {
        private readonly IHtmlGenerator _htmlGenerator;
    
        public RazorTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }
    
        [ViewContext]
        public ViewContext ViewContext { set; get; }
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            var actionAnchor = _htmlGenerator.GenerateActionLink(
                ViewContext,
                linkText: "Home",
                actionName: "Index",
                controllerName: null,
                fragment: null,
                hostname: null,
                htmlAttributes: null,
                protocol: null,
                routeValues: null
                );
            var builder = new HtmlContentBuilder();
            builder.AppendHtml("Here's the link: ");
            builder.AppendHtml(actionAnchor);
            output.Content.SetHtmlContent(builder);
        }
    }

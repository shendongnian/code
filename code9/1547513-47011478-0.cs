    [HtmlTargetElement("editor", Attributes = "asp-for", TagStructure = TagStructure.WithoutEndTag)]
    public class EditorTagHelper : TagHelper
    {
        private HtmlHelper _htmlHelper;
        private HtmlEncoder _htmlEncoder;
        public EditorTagHelper(IHtmlHelper htmlHelper, HtmlEncoder htmlEncoder)
        {
            _htmlHelper = htmlHelper as HtmlHelper;
            _htmlEncoder = htmlEncoder;
        }
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        [ViewContext]
        public ViewContext ViewContext
        {
            set => _htmlHelper.Contextualize(value);
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var partial = await _htmlHelper.PartialAsync("TagHelpers/Editor", For);
            var writer = new StringWriter();
            partial.WriteTo(writer, _htmlEncoder);
            output.Content.SetHtmlContent(writer.ToString());
        }
    }

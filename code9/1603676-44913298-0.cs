    [HtmlTargetElement("widget", Attributes = WidgetNameAttributeName)]
    public class WidgetTagHelper : TagHelper
    {
        private const string WidgetNameAttributeName = "name";
        private readonly IViewComponentHelper _viewComponentHelper;
        public WidgetTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        [HtmlAttributeName(WidgetNameAttributeName)]
        public string Name { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html viewComponentHelper
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);
            var content = await _viewComponentHelper.InvokeAsync(typeof(WidgetViewComponent), new { name = Name });
            output.Content.SetHtmlContent(content);
        }
    }

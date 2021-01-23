    public class CustomTagHelper : TagHelper
        {
            private readonly IHtmlHelper html;
            [HtmlAttributeName("asp-for")]
            public ModelExpression DataModel { get; set; }
            [HtmlAttributeNotBound]
            [ViewContext]
            public ViewContext ViewContext { get; set; }
            public CustomTagHelper(IHtmlHelper htmlHelper)
            {
                html = htmlHelper;
            }
            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                //Contextualize the html helper
                (html as IViewContextAware).Contextualize(ViewContext);
                var content = await html.PartialAsync("~/Views/path/to/TemplateName.cshtml", DataModel.Model);
                output.Content.SetHtmlContent(content);
            }
        }

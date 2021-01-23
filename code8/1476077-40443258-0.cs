    public class CustomTagHelper : TagHelper
        {
            [HtmlAttributeName("asp-for")]
            public ModelExpression DataModel { get; set; }
    
            [HtmlAttributeName("html-helper")]
            public IHtmlHelper Html { get; set; }
    
            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                var content = await Html.PartialAsync("TemplateName", DataModel.Model);
                output.Content.SetContent(content);
            }
        }

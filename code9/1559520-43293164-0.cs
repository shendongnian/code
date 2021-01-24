    public class FooTagHelper : TagHelper
    {
        public ModelExpression For { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent(
    $@"You want the value of property <strong>{For.Name}</strong>
    which is <strong>{For.Model}</strong>");
        }
    }

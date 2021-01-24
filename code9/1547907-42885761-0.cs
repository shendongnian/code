    [HtmlTargetElement("auto-price", Attributes = "[make^=gm],[model]")]
    public class AutoPriceTagHelper : TagHelper
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.Content.SetHtmlContent(
    $@"<li>Make: {Make}</li>
    <li>Model: {Model}</li>");
        }
    }

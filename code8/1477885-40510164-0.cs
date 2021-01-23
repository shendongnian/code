    public class CustomerTagHelper: TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression Source { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.TagMode = TagMode.StartTagAndEndTag;
            
            var contents = $@"
                Model name: {Source.Metadata.ContainerType.FullName}<br/>
                Property name: {Source.Name}<br/>
                Current Value: {Source.Model}<br/> 
                Is Required: {Source.Metadata.IsRequired}";
            output.Content.SetHtmlContent(new HtmlString(contents));
        }
    }

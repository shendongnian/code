    [HtmlTargetElement("*", Attributes = forName)]
    public class NameAppenderTagHelper : TagHelper
    {
        private const string forName = "na-for";
        [HtmlAttributeName(forName)]
        public ModelExpression PropertyName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // add the property name as an attribute to the element
            output.Attributes.Add("data-property-name", PropertyName.Name);
            // if you'd like the [Display] name value, you can use this:
            // output.Attributes.Add("data-property-name", PropertyName.Metadata.DisplayName);
            base.Process(context, output);
        }
    }

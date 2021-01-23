    [HtmlTargetElement("input", Attributes = ForAttributeName)]
    public class ExtendedInputTagHelper : InputTagHelper
    {
        private const string ForAttributeName = "asp-for";
        public ExtendedInputTagHelper(IHtmlGenerator generator)
            : base(generator) { }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var isContentModified = output.IsContentModified;
            if (For.Metadata.IsReadOnly)
            {
                var attribute = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(attribute);
            }
            if (!isContentModified)
            {
                base.Process(context, output);
            }
        }
    }

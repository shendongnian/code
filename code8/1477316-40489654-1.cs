    [HtmlTargetElement("input", Attributes = ForAttributeName)]
    public class MyCustomTextArea : InputTagHelper
    {
        private const string ForAttributeName = "asp-for";
        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; }
        public MyCustomTextArea(IHtmlGenerator generator) : base(generator)
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsDisabled)
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }
            base.Process(context, output);
        }
    }

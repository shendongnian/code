    [HtmlTargetElement("input", Attributes = ForAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InvariantDecimalTagHelper : InputTagHelper
    {
        private const string ForAttributeName = "asp-for";
        private IHtmlGenerator _generator;
        [HtmlAttributeName("asp-is-invariant")]
        public bool IsInvariant { set; get; }
        public InvariantDecimalTagHelper(IHtmlGenerator generator) : base(generator)
        {
            _generator = generator;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (IsInvariant && output.TagName == "input" && For.Model.GetType() == typeof(decimal))
            {
                decimal value = (decimal)(For.Model);
                var invariantValue = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
                output.Attributes.SetAttribute(new TagHelperAttribute("value", invariantValue));                
            }
        }
    }

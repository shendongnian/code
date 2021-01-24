    namespace Project.Helpers
    {
    [HtmlTargetElement("input", Attributes = ForAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InvariantDecimalTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for-invariant";
        private readonly IHtmlGenerator _generator;
        private readonly InputTagHelper _inputTagHelper;
        [HtmlAttributeNotBound]
        [ViewContext]
        public Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
        [HtmlAttributeName("asp-for-invariant")]
        public ModelExpression For { get; set; }
        [HtmlAttributeName("asp-format")]
        public string Format { get; set; }
        [HtmlAttributeName("type")]
        public string InputTypeName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public InvariantDecimalTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
            _inputTagHelper = new InputTagHelper(_generator);
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            _inputTagHelper.Value = Value;
            _inputTagHelper.Name = Name;
            _inputTagHelper.InputTypeName = InputTypeName;
            _inputTagHelper.Format = Format;
            _inputTagHelper.For = For;
            _inputTagHelper.ViewContext = ViewContext;
            _inputTagHelper.Process(context, output);
            if (output.TagName == "input" && _inputTagHelper.For.Model != null && _inputTagHelper.For.Model.GetType() == typeof(decimal))
            {
                decimal value = (decimal)(_inputTagHelper.For.Model);
                var invariantValue = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
                output.Attributes.SetAttribute(new TagHelperAttribute("value", invariantValue));
            }
        }
    }

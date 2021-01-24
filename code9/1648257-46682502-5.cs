    [HtmlTargetElement("myfield")]
    public class MyFieldTagHelper : TagHelper
    {
        private IHtmlGenerator _htmlGenerator;
        public MyFieldTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }
        public string LabelContent { get; set; }
        public string ValidationContent { get; set; }
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var labelContext = CrateTagHelperContext();
            var labelOutput = CrateTagHelperOutput("label");
            labelOutput.Content.Append(LabelContent);
            
            if (For != null)
            {
                labelOutput.Attributes.Add("for", For.Name);
            }
            var label = new LabelTagHelper(_htmlGenerator)
            {
                ViewContext = ViewContext
            };
            label.Process(labelContext, labelOutput);
            var inputContext = CrateTagHelperContext();
            var inputOutput = CrateTagHelperOutput("input");
            inputOutput.Attributes.Add("class", "form-control");
            var input = new InputTagHelper(_htmlGenerator)
            {
                For = For,
                ViewContext = ViewContext
            };
            input.Process(inputContext, inputOutput);
            var validationContext = CrateTagHelperContext();
            var validationOutput = CrateTagHelperOutput("span");
            validationOutput.Content.Append(ValidationContent);
  
            validationOutput.Attributes.Add("class", "text-danger");
            var validation = new ValidationMessageTagHelper(_htmlGenerator)
            {
                For = For,
                ViewContext = ViewContext
            };
            validation.Process(validationContext, validationOutput);
            output.TagName = "";
            output.Content.AppendHtml(labelOutput);
            output.Content.AppendHtml(inputOutput);
            output.Content.AppendHtml(validationOutput);
        }
        private static TagHelperContext CrateTagHelperContext()
        {
            return new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));
        }
        private static TagHelperOutput CrateTagHelperOutput(string tagName)
        {
            return new TagHelperOutput(
                tagName,
                new TagHelperAttributeList(),
                (a,b) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });
        }
    }

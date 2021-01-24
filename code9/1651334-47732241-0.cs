    [HtmlTargetElement("ul", Attributes = AttributeName)]
    public class ValidationSummaryLiItemsTagHelper : TagHelper
    {
        private const string AttributeName = "model-validation-summary-list";
    
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var errors = ViewContext.ModelState.Where(x => x.Key == "").SelectMany(x => x.Value.Errors).ToList();
            foreach (var error in errors)
            {
                output.Content.AppendFormat("<li>{0}</li>", error.ErrorMessage);
            }
    
            if (errors.Any() == false)
                output.SuppressOutput();
        }
    }

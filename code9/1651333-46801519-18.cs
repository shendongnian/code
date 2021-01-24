    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    
    namespace ValidationSampleWebApplication
    {
        [HtmlTargetElement("div", Attributes = ValidationForAttributeName)]
        public class MytValidationMessageTagHelper : ValidationMessageTagHelper
        {
            private const string ValidationForAttributeName = "asp-validation-for";
            public MytValidationMessageTagHelper(IHtmlGenerator generator) : base(generator)
            {
            }
        }
    }

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    
    namespace ValidationSampleWebApplication
    {
        [HtmlTargetElement("div", Attributes = MyValidationForAttributeName)]
        public class MyValidationTagHelper : TagHelper
        {
            private const string MyValidationForAttributeName = "asp-myvalidation-for";
    
            [HtmlAttributeNotBound]
            [ViewContext]
            public ViewContext ViewContext { get; set; }
    
            [HtmlAttributeName(MyValidationForAttributeName)]
            public ModelExpression For { get; set; }
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                base.Process(context, output);
                ModelStateEntry entry;
                ViewContext.ViewData.ModelState.TryGetValue(For.Name, out entry);
                if (entry != null && entry.Errors.Count > 0)
                {
                    var builder = new TagBuilder("div");
                    builder.AddCssClass("hasError");
                    output.MergeAttributes(builder);   
                }
            }
        }
    }

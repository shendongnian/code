    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
    using Microsoft.Extensions.Options;
    using System.Text.Encodings.Web;
    
    namespace ValidationSampleWebApplication
    {
        public class MyHtmlGenerator : DefaultHtmlGenerator
        {
            public MyHtmlGenerator(IAntiforgery antiforgery, IOptions<MvcViewOptions> optionsAccessor, IModelMetadataProvider metadataProvider, IUrlHelperFactory urlHelperFactory, HtmlEncoder htmlEncoder, ValidationHtmlAttributeProvider validationAttributeProvider) : base(antiforgery, optionsAccessor, metadataProvider, urlHelperFactory, htmlEncoder, validationAttributeProvider)
            {
            }
            public override TagBuilder GenerateValidationMessage(ViewContext viewContext, ModelExplorer modelExplorer, string expression, string message, string tag, object htmlAttributes)
            {
                return base.GenerateValidationMessage(viewContext, modelExplorer, expression, message, tag, htmlAttributes);
            }
            public override TagBuilder GenerateValidationSummary(ViewContext viewContext, bool excludePropertyErrors, string message, string headerTag, object htmlAttributes)
            {
                //return base.GenerateValidationSummary(viewContext, excludePropertyErrors, message, headerTag, htmlAttributes);
                var viewData = viewContext.ViewData;
                if (viewData.ModelState.IsValid)
                    return null;
                var modelStates = ValidationHelpers.GetModelStateList(viewData, excludePropertyErrors);
    
                var htmlSummary = new TagBuilder("div");
                htmlSummary.MergeAttribute("style", "background:#f00;");
                foreach (var modelState in modelStates)
                {
                    for (var i = 0; i < modelState.Errors.Count; i++)
                    {
                        var modelError = modelState.Errors[i];
                        var errorText = ValidationHelpers.GetModelErrorMessageOrDefault(modelError);
    
                        if (!string.IsNullOrEmpty(errorText))
                        {
                            var listItem = new TagBuilder("div");
                            listItem.InnerHtml.SetContent(errorText);
                            htmlSummary.InnerHtml.AppendLine(listItem);
                        }
                    }
                }
                return htmlSummary;
            }
        }
    }

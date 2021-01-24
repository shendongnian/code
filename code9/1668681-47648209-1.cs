    .
    
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace ObApp.Web.TagHelpers
    {
        // Builds form elements to generate the following (for example):
        // <div class="form-group">
        //     <div class="row">
        //         <input ... >Email</input>
        //         <div>
        //             <input type="text" ... />
        //             <span class="field-validation-valid ... ></span>
        //         </div>
        //     </div>
        // </div>
    
        public class FormfieldTagHelper : TagHelper
    
        {
            private const string _forAttributeName = "asp-for";
            private const string _defaultWraperDivClass = "form-group";
            private const string _defaultRowDivClass = "row";
            private const string _defaultLabelClass = "col-md-3 col-form-label";
            private const string _defaultInputClass = "form-control";
            private const string _defaultInnerDivClass = "col-md-9";
            private const string _defaultValidationMessageClass = "";
            
            public FormfieldTagHelper(IHtmlGenerator generator)
            {
                Generator = generator;
            }
    
            [HtmlAttributeName(_forAttributeName)]
            public ModelExpression For { get; set; }
    
            public IHtmlGenerator Generator { get; }
    
            [ViewContext]
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    
            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                // Replace this parent tag helper with div tags wrapping the entire form block
                output.TagName = "div";
                output.Attributes.SetAttribute("class", _defaultWraperDivClass);
    
                // Manually new-up each child asp form tag helper element
                TagHelperOutput labelElement = await CreateLabelElement(context);
                TagHelperOutput inputElement = await CreateInputElement(context);
                TagHelperOutput validationMessageElement = await CreateValidationMessageElement(context);
    
                // Wrap input and validation with column div
                IHtmlContent innerDiv = WrapElementsWithDiv(
                        new List<IHtmlContent>()
                        {
                            inputElement,
                            validationMessageElement
                        },
                        _defaultInnerDivClass
                    );
    
                // Wrap all elements with a row div
                IHtmlContent rowDiv = WrapElementsWithDiv(
                        new List<IHtmlContent>()
                        {
                            labelElement,
                            innerDiv
                        },
                        _defaultRowDivClass
                    );
    
                // Put everything into the innerHtml of this tag helper
                output.Content.SetHtmlContent(rowDiv);
            }
    
            private async Task<TagHelperOutput> CreateLabelElement(TagHelperContext context)
            {
                LabelTagHelper labelTagHelper = 
                    new LabelTagHelper(Generator)
                    {
                        For = this.For,
                        ViewContext = this.ViewContext
                    };
    
                TagHelperOutput labelOutput = CreateTagHelperOutput("label");
    
                await labelTagHelper.ProcessAsync(context, labelOutput);
    
    
                labelOutput.Attributes.Add(
                    new TagHelperAttribute("class", _defaultLabelClass));
    
                return labelOutput;
            }
    
            private async Task<TagHelperOutput> CreateInputElement(TagHelperContext context)
            {
                InputTagHelper inputTagHelper = 
                    new InputTagHelper(Generator)
                    {
                        For = this.For,
                        ViewContext = this.ViewContext
                    };
    
                TagHelperOutput inputOutput = CreateTagHelperOutput("input");
    
                await inputTagHelper.ProcessAsync(context, inputOutput);
                
                inputOutput.Attributes.Add(
                    new TagHelperAttribute("class", _defaultInputClass));
    
                return inputOutput;
            }
    
            private async Task<TagHelperOutput> CreateValidationMessageElement(TagHelperContext context)
            {
                ValidationMessageTagHelper validationMessageTagHelper = 
                    new ValidationMessageTagHelper(Generator)
                    {
                        For = this.For,
                        ViewContext = this.ViewContext
                    };
    
                TagHelperOutput validationMessageOutput = CreateTagHelperOutput("span");
    
                await validationMessageTagHelper.ProcessAsync(context, validationMessageOutput);
    
                return validationMessageOutput;
            }
    
            private IHtmlContent WrapElementsWithDiv(List<IHtmlContent> elements, string classValue)
            {
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass(classValue);
                foreach(IHtmlContent element in elements)
                {
                    div.InnerHtml.AppendHtml(element);
                }
                return div;
                
            }
    
            private TagHelperOutput CreateTagHelperOutput(string tagName)
            {
                return new TagHelperOutput(
                    tagName: tagName,
                    attributes: new TagHelperAttributeList(),
                    getChildContentAsync: (s, t) =>
                    {
                        return Task.Factory.StartNew<TagHelperContent>(
                                () => new DefaultTagHelperContent());
                    }
                    );
            }
        }
    }

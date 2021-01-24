    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    namespace AnnotationBasedAttributes
    {
        [HtmlTargetElement("input")]
        public class MyAwesomeTagHelper : TagHelper
        {
            public ModelExpression AspFor { get; set; }
            public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                if (!(this.AspFor.Metadata is DefaultModelMetadata modelMetadata))
                {
                    return Task.CompletedTask;
                }
                var dataTypeAttribute = modelMetadata.Attributes.Attributes.OfType<DataTypeAttribute>().FirstOrDefault();
                if (dataTypeAttribute == null)
                {
                    return Task.CompletedTask;
                }
                var type = dataTypeAttribute.DataType.ToString().ToLower();
                output.Attributes.Add(new TagHelperAttribute("class", type));
                return Task.CompletedTask;
            }
        }
    }

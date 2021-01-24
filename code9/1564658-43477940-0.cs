    namespace YourProject.TagHelpers
    {
        [HtmlTargetElement("input", Attributes = "asp-for")]
        public class MaxLengthTagHelper : TagHelper
        {
            public override int Order { get; } = 999;
    
            [HtmlAttributeName("asp-for")]
            public ModelExpression For { get; set; }
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                base.Process(context, output);
                // Process only if 'maxlength' attr is not present
                if (context.AllAttributes["maxlength"] == null) 
                {
                    // Attempt to check for a MaxLength annotation
                    var maxLength = GetMaxLength(For.ModelExplorer.Metadata.ValidatorMetadata);
                    if (maxLength > 0)
                    {
                        output.Attributes.Add("maxlength", maxLength);
                    }
                }
            }
    
            private static int GetMaxLength(IReadOnlyList<object> validatorMetadata)
            {
                for (var i = 0; i < validatorMetadata.Count; i++)
                {
                    var stringLengthAttribute = validatorMetadata[i] as StringLengthAttribute;
                    if (stringLengthAttribute != null && stringLengthAttribute.MaximumLength > 0)
                    {
                        return stringLengthAttribute.MaximumLength;
                    }
                    var maxLengthAttribute = validatorMetadata[i] as MaxLengthAttribute;
                    if (maxLengthAttribute != null && maxLengthAttribute.Length > 0)
                    {
                        return maxLengthAttribute.Length;
                    }
                }
                return 0;
            }
        }
    }

    public class CustomTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {            
            CustomAttribute attribute = For.Metadata
                                           .ContainerType
                                           .GetProperty(For.Name)
                                           .GetCustomAttribute(typeof(CustomAttribute)) 
                                           as CustomAttribute;
            if (attribute != null)
            {
                output.Attributes.Add("some-attr", attribute.Text);
            }
        }
    }

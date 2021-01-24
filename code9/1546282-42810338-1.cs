    [HtmlTargetElement("user-view")]
    public class UserViewTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Replace user-view with div
            output.TagName = "div";
            // Set class
            output.Attributes.SetAttribute("class", "user-view");
            // Append the inner structure
            output.Content.AppendHtml(...);
        }
    }

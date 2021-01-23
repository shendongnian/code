    using System.Net;
    using System.Text;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    namespace AppName.TagHelpers
    {
        [HtmlTargetElement("nl2br", Attributes = "text")]
        public class Nl2brTagHelper : TagHelper
        {
            [HtmlAttributeName("text")]
            public string Text { get; set; }
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName = string.Empty;
                StringBuilder builder = new StringBuilder();
                string[] lines = Text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i > 0)
                    {
                        builder.Append("<br/>");
                    }
                    builder.Append(WebUtility.HtmlEncode(lines[i]));
                }
                output.Content.SetHtmlContent(builder.ToString());
            }
        }
    }

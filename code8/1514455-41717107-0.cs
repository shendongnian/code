    public class Nl2BrTagHelper : TagHelper
    {
        //Set this as <nl2br text=
        public string Text { get; set; } 
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";    // Replaces <nl2br> with <div> tag
    
                StringBuilder builder = new StringBuilder();
                string[] lines = Text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i > 0)
                        builder.Append("<br/>");
                    builder.Append(HttpUtility.HtmlEncode(lines[i]));
                }
            output.Content.SetContent(builder.ToString());
        }
    }

    [HtmlTargetElement("myfield")]
    public class MyFieldTagHelper : TagHelper
    {
        // Can be set as follows <myfield asp-for="..." />. 
        public string AspFor { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var template = $"<label asp-for=\"{AspFor}\"></label>\n" +
                "<input asp-for=\"{AspFor}\" class=\"form-control\"/>\n" +
            "<span asp-validation-for=\"{AspFor}\" class=\"text-danger\"></span>";
            output.TagName = "";
            output.Content.AppendHtml(template);
        }
    }

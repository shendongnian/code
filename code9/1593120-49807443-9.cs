    [HtmlTargetElement("script", Attributes = "delay")]
    public class ScriptDelayTagHelper : TagHelper
    {
        /// <summary>
        /// Delay script execution until the end of the page
        /// </summary>
        public bool Delay { get; set; }
        /// <summary>
        /// Execute only after this external script file is loaded
        /// </summary>
        [HtmlAttributeName("after")]
        public string After { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Delay) base.Process(context, output);
            var content = output.GetChildContentAsync().Result;
            var javascript = content.GetContent();
            var sb = new StringBuilder();
            sb.Append("if (!MYCOMPANY || !MYCOMPANY.delay) throw 'MYCOMPANY.delay missing.';");
            sb.Append("MYCOMPANY.delay(function() {");
            sb.Append(LoadFile(javascript));
            sb.Append("});");
            output.Content.SetHtmlContent(sb.ToString());
        }
        string LoadFile(string javascript)
        {
            if (After == NullOrWhiteSpace)
                return javascript;
            var sb = new StringBuilder();
            sb.Append("if (!MYCOMPANY || !MYCOMPANY.loadScript) throw 'MYCOMPANY.loadScript missing.';");
            sb.Append("MYCOMPANY.loadScript(");
            sb.Append($"'{After}',");
            sb.Append("function() {");
            sb.Append(javascript);
            sb.Append("});");
            return sb.ToString();
        }
    }

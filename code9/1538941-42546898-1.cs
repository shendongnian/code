    public static MvcHtmlString TestHelpLink(this HtmlHelper htmlHelper, string helpTopic)
    {
        var sb = new StringBuilder();
        // taken from /a/363994/6378815
        var url = new UrlHelper(htmlHelper.ViewContext.RequestContext);
    
        var builder = new TagBuilder("a");
        builder.MergeAttribute("target", "_blank");
        builder.MergeAttribute("href", url.Content("~/help/" + helpTopic + ".html"));
    
        sb.Append(builder.ToString(TagRenderMode.StartTag));
        sb.Append("<i class='glyphicon glyphicon-question-sign'>Link Text</i>");
        sb.Append(builder.ToString(TagRenderMode.EndTag));
    
        return MvcHtmlString.Create(sb.ToString());
    }

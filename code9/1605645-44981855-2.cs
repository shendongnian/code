    var baseUrl = VirtualPathUtility.AppendTrailingSlash(HttpRuntime.AppDomainAppPath);
    var tb = new TagBuilder("img");
    tb.MergeAttribute("title", "Main Image");
    tb.MergeAttribute("src", baseUrl +"images/test.jpg");  //notice I removed the initial slash
    return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));

    public static MvcHtmlString CustomActionLink(this HtmlHelper html, string action, string controller,
              string displayText, bool isCreate)
            {
                if (isCreate)
                {
                    var targetUrl = UrlHelper.GenerateUrl("Default", action, controller,
                       null, RouteTable.Routes, html.ViewContext.RequestContext, false);
                    var anchorBuilder = new TagBuilder("a");
                    anchorBuilder.MergeAttribute("href", targetUrl);
                    string classes = "btn btn-progress";
                    anchorBuilder.MergeAttribute("class", classes);
    
                    //Return as MVC string
                    anchorBuilder.InnerHtml = displayText;
                    return new MvcHtmlString(anchorBuilder.ToString(TagRenderMode.Normal));
                }
                else
                {
                    var spanBuilder = new TagBuilder("span");
                    spanBuilder.MergeAttribute("class", "btn btn-progress");
                    spanBuilder.InnerHtml = displayText;
                    return new MvcHtmlString(spanBuilder.ToString(TagRenderMode.Normal));
                }
            }

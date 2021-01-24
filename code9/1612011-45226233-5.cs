    using System.Web.Routing;
    public static MvcHtmlString MenuLink(this HtmlHelper helper,
        string text, string action, string controller, object htmlAttributes)
    {
        var routeData = helper.ViewContext.RouteData.Values;
        var currentController = routeData["controller"];
        var currentAction = routeData["action"];
        IDictionary<string, object> attrs = new RouteValueDictionary(htmlAttributes);
        if (String.Equals(action, currentAction as string,
                StringComparison.OrdinalIgnoreCase)
            && String.Equals(controller, currentController as string,
                    StringComparison.OrdinalIgnoreCase))
        {
            string clazz;
            if (attrs.TryGetValue("class", out clazz))
            {
                attrs["class"] = clazz + " " + "currentMenuItem";
            }
            // do you need to handle the case when there is no "class" attribute?
            return helper.ActionLink(text, action, controller, attrs);
        }
        return helper.ActionLink(text, action, controller, htmlAttributes);
    }

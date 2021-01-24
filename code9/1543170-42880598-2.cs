    public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
    {
      if (htmlHelper.ActionAuthorized(actionName, controllerName))
      {
        return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
      }
      else
      {
        return MvcHtmlString.Empty;
      }
    }

        public static IUrlHelper GetUrlHelper(this IHtmlHelper html)
        {
            var urlFactory = html.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            var actionAccessor = html.ViewContext.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
            return urlFactory.GetUrlHelper(actionAccessor.ActionContext);
        }
        public static IHtmlContent MenuLink(this IHtmlHelper htmlHelper, string linkText, string controller, string action, string area, string anchorTitle)
        {
            
            var urlHelper = htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(action, controller, new { area });
            var anchor = new TagBuilder("a");
            anchor.InnerHtml.Append(linkText);
            anchor.MergeAttribute("href", url);
            anchor.Attributes.Add("title", anchorTitle);
            var listItem = new TagBuilder("li");
            listItem.InnerHtml.AppendHtml(anchor);
            if (CheckForActiveItem(htmlHelper, controller, action, area))
            {
                listItem.GenerateId("menu_active", "_");
            }
            return listItem;
        }

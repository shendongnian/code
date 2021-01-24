    public static bool IsActive(this HtmlHelper htmlHelper, params int[] ids)
    {
        var viewContext = htmlHelper.ViewContext;
        return viewContext.TempData.ContainsKey(DomainKeys.ViewPageId) && 
            int.Parse(viewContext.TempData.Peek(DomainKeys.ViewPageId).ToString()).In(ids);
    }

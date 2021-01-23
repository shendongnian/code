    private static IEnumerable<SelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name)
    {
        object o = null;
        if (htmlHelper.ViewData != null)
        {
            o = htmlHelper.ViewData.Eval(name);
        }
        ...

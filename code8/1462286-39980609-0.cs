    private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
    {
        ...
        // If we got a null selectList, try to use ViewData to get the list of items.
        if (selectList == null)
        {
           selectList = htmlHelper.GetSelectData(name);
           ...

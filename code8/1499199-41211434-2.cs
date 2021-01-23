     IEnumerable<SelectListItem> selectList = o as IEnumerable<SelectListItem>;
    if (selectList == null)
    {
        throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, 
            MvcResources.HtmlHelper_WrongSelectDataType,
            name, o.GetType().FullName, "IEnumerable<SelectListItem>"));
    }

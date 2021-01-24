    public static List<SelectListItem> ToSelectItemList<T>(IQueryable<T> collection) 
       where T : IDropDownItem
    {
        return collection.Select(m => new SelectListItem
        {
            Text = m.Name,
            Value = m.Id.ToString()
        }).ToList();
    }

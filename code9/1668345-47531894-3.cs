    public static List<SelectListItem> ToSelectItemList<T>(IEnumerable<T> collection) 
       where T : IDropDownItem
    {
        return collection.Select(m => new SelectListItem
        {
            Text = m.Name,
            Value = m.Id.ToString()
        }).ToList();
    }

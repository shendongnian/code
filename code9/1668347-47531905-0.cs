    public interface ISelectable
    {
        string Name { get; }
        int Id { get; }
    }
    public static List<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> collection)
        where T: ISelectable
    {
        return collection.Select(m => new SelectListItem
        {
            Text = m.Name,
            Value = m.Id.ToString()
        }).ToList();
    }

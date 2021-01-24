    public static class EnumerableExtensions
    {
    	public static List<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> collection)
    		where T : Program
    	{
    		return collection.Select(m => new SelectListItem
    		{
    			Text = m.Name,
    			Value = m.Id.ToString()
    		}).ToList();
    	}
    }

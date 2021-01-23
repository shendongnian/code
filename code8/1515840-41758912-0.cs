    public static IEnumerable<T> myFilter<T>(List<T> source, string propertyName, string searchString)
    {
    	// get the myclass property then the stated property(Name) value within it
    	searchString = searchString.ToLower();
    	return source.Where(s => (s.GetType().GetProperty("myclass")
    								.PropertyType.GetProperty(propertyName)
    								.GetValue(s.GetType().GetProperty("myclass").GetValue(s)).ToString() ?? " ")
    								.ToLower().Contains(searchString));
    }

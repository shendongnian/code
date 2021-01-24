    public interface IWidgetService
    {
        [Get("/widget/list/{Name}")]
        Task<List<Widget>> List(string Name);
    }
    private string GetUrl()
    {
        PropertyInfo property = typeof(IWidgetService).GetProperty("List");
        object[] attributes = property.GetCustomAttributes(true);
        foreach (var attr in attributes)
        {
            GetAttribute attribute = attr as GetAttribute;
            if (attribute != null)
            {
                return attribute.Path;
            }
        }
        throw new Exception("Unable to get API URL");
    }

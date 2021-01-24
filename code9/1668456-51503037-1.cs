    public interface IWidgetService
    {
        [Get("/widget/list/{Name}")]
        Task<List<Widget>> List(string Name);
    }
    private string GetUrl()
    {
        MethodInfo method = typeof(IWidgetService).GetMethod("List");
        object[] attributes = method.GetCustomAttributes(true);
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

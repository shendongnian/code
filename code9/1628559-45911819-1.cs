    public static T CreateNewRowInModel<T>(
        IList<PropertyInfo> propertiesView, IList<PropertyInfo> propertiesModel, object source)
        where T : new() 
    {
        T item = new T();
        foreach (var p in propertiesView)
        {
            object value = p.GetValue(source);
            foreach (var property in propertiesModel)
            {
                // Optional, not shown:
                // For added security, check that the types are the same also
                if (property.Name == p.Name)
                {
                    property.SetValue(item, value);
                    break;
                }
            }
        }
        return item;
    }

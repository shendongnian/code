    public static class PropertyInfoExtension
    {
        public void SetValue(this PropertyInfo propertyInfo, object obj, object value)
        {
            propertyInfo.SetValue(obj, value);
        }
    }

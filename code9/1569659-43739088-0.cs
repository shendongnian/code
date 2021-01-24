    public class DictionaryConverter : ITypeConverter
    {
        public int Order => 110;
        public bool CanConvert(object value, Type type)
        {
            // Handle Nullable types
            var conversionType = Nullable.GetUnderlyingType(type) ?? type;
            //Check if Type is a Dictionary
            return conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }
        public object Convert(object value, Type type)
        {
            // Handle Nullable types
            var conversionType = Nullable.GetUnderlyingType(type) ?? type;
            //Create Empty Instance
            object result = Activator.CreateInstance(type);
            if (value != null)
            {
                try
                {
                    result = JsonConvert.DeserializeObject(value as string, type);
                }
                catch (JsonException ex)
                {
                    throw new Exception("Invalid JSON String while Converting to Dictionary Object", ex);
                }
            }
            return result;
        }
    }

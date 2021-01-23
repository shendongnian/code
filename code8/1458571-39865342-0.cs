    public static class Mapper
    {
        public static T Map<T>(Object source) where T : class
        {
            var instance = Activator.CreateInstance<T>();
    
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.CanRead)
                {
                    var sourceProperty = source.GetType().GetProperty(property.Name);
    
                    if (sourceProperty == null)
                    {
                        continue;
                    }
    
                    var value = sourceProperty.GetValue(source);
    
                    property.SetValue(instance, value);
                }
            }
    
            return instance;
        }
    }

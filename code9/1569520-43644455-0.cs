    public class PropertyPopulator
    {
        public void PopulateProperties(object target)
        {
            var properties = target.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.PropertyType.IsClass && p.CanWrite && p.CanRead);
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(target);
                if (propertyValue == null)
                {
                    var constructor = property.PropertyType.GetConstructor(new Type[] { });
                    if (constructor != null)
                    {
                        propertyValue = constructor.Invoke(new object[] { });
                        property.SetValue(target, propertyValue);
                        PopulateProperties(propertyValue);
                    }
                }
            }
        }
    }

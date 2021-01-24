    public class DataMemberBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var props = bindingContext.ModelType.GetProperties();
            var result = Activator.CreateInstance(bindingContext.ModelType);
            foreach (var property in props)
            {
                try
                {
                    var attributes = property.GetCustomAttributes(typeof(DataMemberAttribute), true);
                    var key = attributes.Length > 0
                        ? ((DataMemberAttribute)attributes[0]).Name
                        : property.Name;
                    if (bindingContext.ValueProvider.ContainsPrefix(key))
                    {
                        var value = bindingContext.ValueProvider.GetValue(key).ConvertTo(property.PropertyType);
                        property.SetValue(result, value);
                    }
                }
                catch
                {
                    // log that property can't be set or throw an exception
                }
            }
            bindingContext.Model = result;
            return true;
        }
    }

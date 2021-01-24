    private static void ApplyDefaults(object model)
        {
            PropertyInfo[] properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                DefaultAttribute defaultAttr = property.GetCustomAttribute<DefaultAttribute>();
                if (defaultAttr != null)
                    property.SetValue(model, defaultAttr.Value);
            }
        }

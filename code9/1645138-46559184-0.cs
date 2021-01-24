    private static ConcurrentDictionary<string, object> GetColumnFromClass(object obj, ConcurrentDictionary<string, object> fields)
            {
                //null type will not be processed
                if (obj == null)
                    return null;
               
                Type objType = obj.GetType();
                PropertyInfo[] properties = objType.GetProperties();
    
                foreach (PropertyInfo property in properties)
                {
                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        Type itemType = property.PropertyType.GetGenericArguments()[0];
                        if (itemType == typeof(string))
                            fields.AddOrUpdate(property.Name, property.PropertyType.Name.ToUpper(), (k, o) => o);
                        else
                        {
                            fields.AddOrUpdate(property.Name, property.PropertyType.Name.ToUpper(), (k, o) => o);
                            GetColumnFromClass(Activator.CreateInstance(itemType), fields);
                        }
                    }
                    else
                    {
                        object propVal = property.GetValue(obj, null);
                        if (property.PropertyType.Assembly == objType.Assembly)
                        {
                            fields.AddOrUpdate(property.Name, property.PropertyType.Name.ToUpper(), (k,o) => o);
                            GetColumnFromClass(propVal, fields);
                        }
                        else
                        {
                            fields.AddOrUpdate(property.Name, property.PropertyType.Name.ToUpper(), (k, o) => o);
                        }
                    }
                }
                return fields;
            }

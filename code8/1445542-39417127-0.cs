     public string GetString<T>(T @object)
            {
                var output = new StringBuilder();
                var type = typeof(T);
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(typeof(HubspotAttribute), true);
                    if (attributes.Length == 0)
                        continue;
    
                    var name = ((HubspotAttribute)attributes[0]).hubspotValue;
                    var value = property.GetValue(@object) ?? "none";
                    output.AppendFormat("{0}:\"{1}\",", name, value);
                }
    
                var fields = output.ToString().TrimEnd(',');
                return string.Format("[{0}]", fields);
    
            }

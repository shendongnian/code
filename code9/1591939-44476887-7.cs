    public static class DynamicExtensions
    {
        public static dynamic ToDynamic(this object value)
        {
            var list = new List<ExpandoObject>();
            foreach (var item in (List<dynamic>)value)
            {
                IDictionary<string, object> expando = new ExpandoObject();
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(item.GetType()))
                {
                    expando.Add(property.Name, property.GetValue(item));
                }
                list.Add(expando as ExpandoObject);
            }
            return list;
        }
    }

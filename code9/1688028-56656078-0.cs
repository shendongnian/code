        public static T DefaultLists<T>(this T obj)
        {
            var properties = obj.GetType().GetProperties().Where(q => q.PropertyType.Name == "List`1" && q.GetValue(obj) == null);
            foreach(var property in properties)
                property.SetValue(obj, Activator.CreateInstance(property.PropertyType));
            return obj;
        }

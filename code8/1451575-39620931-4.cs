    public class SummaryFactory
    {        
        // new instance with values assigned by action delegate or default
        public T Create<T>(Action<T> action = null) 
            where T : ISummary, new()
        {
            var result = new T();
            action?.Invoke(result);
             
            return result;
        }
        // with object to assign value from (map) 
        public T Create<T>(object map)
            where T : ISummary, new()
        {
            var result = new T();
            PropertyInfo[] props = map.GetType().GetProperties();
            PropertyInfo[] tProps = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var upperPropName = prop.Name.ToUpper();
                var foundProperty = tProps.FirstOrDefault(p => p.Name.ToUpper() == upperPropName);
                foundProperty?.SetValue(result, prop.GetValue(map));
            }
            return result;
        }
        // new instance without generic parameters
        public object Create(Type type)
        {
            var result = Activator.CreateInstance(type);
            // add all logic that you need
             
            return result;
        }
    }

    public class Mapper<T>
    {
		readonly List<PropertyInfo> properties = typeof(T).GetProperties().OrderBy(p => p.Name).ToList();
		
        public T Map(string line, char delimitter)
        {
            if (String.IsNullOrEmpty(line))
                throw new ArgumentNullException("line");
            if (Char.IsWhiteSpace(delimitter))
                throw new ArgumentException("delimiter");
            var splitString = line.Split(delimitter);
            if (properties.Count() != splitString.Count())
                throw new InvalidOperationException(string.Format("Row has {0} columns but object has {1}", splitString.Count(), properties.Count()));
			// Create as a reference (boxed if a value type).
            object obj = Activator.CreateInstance(typeof(T));
			// Set the property values on the object reference.
            for (var i = 0; i < splitString.Count(); i++)
            {
                var prop = properties[i];
                var propType = prop.PropertyType;
                var valType = Convert.ChangeType(splitString[i], propType);
                prop.SetValue(obj, valType);
            }
			// Cast to the return type unboxing if required.
            return (T)obj;
        }
    }

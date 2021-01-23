        /// <summary>
        /// Create a new instance of the dynamic type.
        /// </summary>
        /// <param name="typeName">The name of the type.</param>
        /// <param name="properties">The collection of properties to create in the type.</param>
        /// <param name="methods">The collection of methods to create in the type.</param>
        /// <returns>The new instance of the type.</returns>
        public object Create(string typeName, IEnumerable<DynamicPropertyValue> properties, IEnumerable<DynamicMethod> methods)
        {
            // Make sure the page reference exists.
            if (typeName == null) throw new ArgumentNullException("typeName");
            if (properties == null) throw new ArgumentNullException("properties");
            if (methods == null) throw new ArgumentNullException("methods");
            _typeName = typeName;
            // Create the dynamic type collection
            List<DynamicProperty> prop = new List<DynamicProperty>();
            foreach (DynamicPropertyValue item in properties)
                prop.Add(new DynamicProperty(item.Name, item.Type));
            // Return the create type.
            object instance = CreateEx(typeName, prop.ToArray(), methods);
            PropertyInfo[] infos = instance.GetType().GetProperties();
            // Assign each type value
            foreach (PropertyInfo info in infos)
                info.SetValue(instance, properties.First(u => u.Name == info.Name).Value, null);
            // Return the instance with values assigned.
            return instance;
        }

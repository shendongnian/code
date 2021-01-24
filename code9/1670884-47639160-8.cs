        public static void FindSpecialProperties(PropertyInfo property, List<PropertyInfo> allProperties, HashSet<PropertyInfo> recursivedProperties)
        {
            if (recursivedProperties.Contains(property))//Eliminate already recursived property
            {
                return;
            }
            recursivedProperties.Add(property);
            var properties = property.PropertyType.GetProperties();
            if (properties.Length == 0)
            {
                return;
            }
            foreach (var propertyInfo in properties)
            {
                var singleNestedPropertyIndex = propertyInfo.GetCustomAttribute<SingleIndexAttribute>();
                var groupNestedIndex = propertyInfo.GetCustomAttribute<GroupIndexAttribute>();
                var ttlIndex = property.GetCustomAttribute<TTLIndexAttribute>();
                if (singleNestedPropertyIndex != null || groupNestedIndex != null || ttlIndex != null)
                {
                    allProperties.Add(propertyInfo);
                }
                allProperties.Add(propertyInfo);
                FindSpecialProperties(propertyInfo, allProperties, recursivedProperties);
            }
        }

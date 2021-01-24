        public static void FindSpecialProperties(PropertyInfo property, List<PropertyInfo> allProperties, List<int> recursivedProperties)
        {
            if (recursivedProperties.Contains(property.GetHashCode()))//Eliminate already recursived property
            {
                return;
            }
            recursivedProperties.Add(property.GetHashCode());
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
                FindSpecialProperties(propertyInfo, allProperties, recursivedProperties);
            }
        }

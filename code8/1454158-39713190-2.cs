        static void Populate(object from, object to)
        {
            var sourceType = from.GetType();
            foreach (PropertyInfo target in to.GetType().GetProperties())
            {
                // Is the property at the target object writable and *not* marked
                // as `[NotMapped]'?
                var isUpdatable =
                    target.CanWrite &&
                    (target.GetCustomAttribute<NotMappedAttribute>(true) == null);
                if (isUpdatable)
                {
                    // If so, just find the corresp. property with the same name at the source object
                    var source = sourceType.GetProperty(target.Name);
                    var @default = sourceType.IsValueType ? Activator.CreateInstance(sourceType) : null;
                    var equality = (IEqualityComparer)typeof(EqualityComparer<>).MakeGenericType(sourceType).GetProperty("Default", BindingFlags.Public | BindingFlags.Static).GetValue(null);
                    var value = source.GetValue(from);
                    // Test for <property value> != default(<property type>)
                    if (!equality.Equals(value, @default))
                    {
                        target.SetValue(to, value, null);
                    }
                }
            }
        }

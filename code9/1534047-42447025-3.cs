    public static partial class XmlAttributeOverridesExtensions
    {
        public static XmlAttributeOverrides IgnorePropertiesOfType(this XmlAttributeOverrides overrides, Type declaringType, Type propertyType)
        {
            return overrides.IgnorePropertiesOfType(declaringType, propertyType, new HashSet<Type>());
        }
        public static XmlAttributeOverrides IgnorePropertiesOfType(this XmlAttributeOverrides overrides, Type declaringType, Type propertyType, HashSet<Type> completedTypes)
        {
            if (overrides == null || declaringType == null || propertyType == null || completedTypes == null)
                throw new ArgumentNullException();
            XmlAttributes attributes = null;
            for (; declaringType != null && declaringType != typeof(object); declaringType = declaringType.BaseType)
            {
                // Avoid duplicate overrides.
                if (!completedTypes.Add(declaringType))
                    break;
                foreach (var property in declaringType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                {
                    if (property.PropertyType == propertyType || Nullable.GetUnderlyingType(property.PropertyType) == propertyType)
                    {
                        attributes = attributes ?? new XmlAttributes { XmlIgnore = true };
                        overrides.Add(declaringType, property.Name, attributes);
                    }
                }
            }
            return overrides;
        }
    }

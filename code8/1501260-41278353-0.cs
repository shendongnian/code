    public static class TypeExtensions
    {
		public static bool IsGenericList(this Type type)
		{
			return type.GetGenericListItemType() != null;
		}
        public static Type GetGenericListItemType(this Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(List<>))
                        return type.GetGenericArguments()[0];
                }
                type = type.BaseType;
            }
            return null;
        }
    }

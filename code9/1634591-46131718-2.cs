        private static T[] GetEnumValues<T>()
            where T : struct
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException();
            }
            T[] values = type.GetFields()
                .Where(fi => !fi.IsSpecialName)
                .Select(fi => fi.GetValue(null))
                .Cast<T>()
                .ToArray();
            return values;
        }

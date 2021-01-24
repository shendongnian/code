        public static List<T> GetAttributesByFlags<T>(this Enum arg) where T: Attribute
        {
            var type = arg.GetType();
            var result = new List<T>();
            foreach (var item in Enum.GetValues(type))
            {
                var value = (Enum)item;
                if (arg.HasFlag(value)) // it means that '(arg & value) == value'
                {
                    var memInfo = type.GetMember(value.ToString())[0];
                    result.Add((T)memInfo.GetCustomAttribute(typeof(T), false));
                }
            }
            return result;
        }

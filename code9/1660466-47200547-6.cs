    public static String GetDescription<TEnum>(TEnum @enum) where TEnum: struct
            {
                var description = typeof(TEnum)
                    .GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                    .Single(x => EqualityComparer<TEnum>.Default.Equals((TEnum)x.GetValue(null), @enum))
                    .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)
                    .OfType<DescriptionAttribute>()
                    .OrderBy(x => x.Weight)
                    .Select(x => x.Value)
                    .DefaultIfEmpty(@enum.ToString())
                    .First();
    
                return description;
            }

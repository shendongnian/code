            private static string GetEnumDescription<TEnum>(TEnum item, string enumName) where TEnum: struct
            {
                Type type = item.GetType(); 
    
                var attribute =
                    type.GetField(item.ToString())
                        .GetCustomAttributes(typeof (DescriptionAttribute), false)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault();
    
                return attribute == null
                    ? enumName
                        .FirstCharToUpper()
                        .ToSeparatedWords() 
                    : attribute.Description;
            }

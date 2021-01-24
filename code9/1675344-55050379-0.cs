    /// <summary>Pseudo extension class for enumerations</summary>
    /// <typeparam name="TEnum">Enumeration type</typeparam>
    public class Utils<TEnum> where TEnum : struct, IConvertible
    {
        public static List<Dropdown> ConvertToDropdown()
        {
            var enumType = typeof(TEnum);
    
            return enumType.IsEnum
                ? enumType.GetEnumValues()
                    .OfType<TEnum>()
                    .Select(e => new Dropdown
                    {
                        Id = Convert.ToInt32(Enum.Parse(enumType, e.ToString()) as Enum),
                        Name = GetDisplay(e)
                    })
                    .ToList()
                : throw new ArgumentException($"{enumType.Name} is not enum");
        }
    
        private static string GetDisplay<T>(T value)
        {
            var enumValueText = value.ToString();
    
            var displayAttribute = value
                .GetType()
                .GetField(enumValueText)
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();
    
            return displayAttribute == null ? enumValueText : displayAttribute.Description;
        }
    }

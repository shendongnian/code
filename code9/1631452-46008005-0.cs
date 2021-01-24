    public class Enums
    {
        private static readonly IReadOnlyDictionary<string, Enum> mappings = typeof(Enums).GetNestedTypes()
            .Where(x => x.IsEnum)
            .SelectMany(x => x.GetEnumValues().Cast<Enum>())
            .ToDictionary(x => x.ToString(), x => x);
        public static Enum Parse(string value)
        {
            Enum result;
            if (!mappings.TryGetValue(value, out result))
                throw new ArgumentOutOfRangeException("Value: " + value);
            
            return result;
        }
        // your enum types below...
    }

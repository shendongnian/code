     public static string Description(this Enum eValue)
        {
            var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (nAttributes.Any())
            {
                var descriptionAttribute = nAttributes.First() as DescriptionAttribute;
                if (descriptionAttribute != null)
                    return descriptionAttribute.Description;
            }
            // If no description is found, the least we can do is replace underscores with spaces
            TextInfo oTI = CultureInfo.CurrentCulture.TextInfo;
            return oTI.ToTitleCase(oTI.ToLower(eValue.ToString().Replace("_", " ")));
        }     
    public static IEnumerable<KeyValuePair<string, string>> GetAllValuesAndDescriptions<TEnum>() where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an Enumeration type");
            }
            return from e in Enum.GetValues(typeof(TEnum)).Cast<Enum>()
                   select new KeyValuePair<string, string>(e.ToString(), e.Description());
        }

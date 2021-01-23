    object IConvertible.ToType(Type conversionType, IFormatProvider provider)
    {
        if (conversionType == typeof(Sampo.CMS.LocalizedString))
        {
            // Do your conversion here and return the string.
            return this.ToString() + "!!!!";
        }
        throw new InvalidCastException($"Converting type \"{typeof(LocalizedString )}\" to type \"{conversionType.Name}\" is not supported.");
    }

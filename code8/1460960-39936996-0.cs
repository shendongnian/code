    public enum priceLevels
    {
        [Description("Partner-Select")]
        SELECT = 2,
        [Description("...")]
        PLUS = 3,
        [Description("...")]
        PREMIER = 3,
        [Description("...")]
        EFI = 4,
        [Description("...")]
        MSELECT = 5,
        [Description("...")]
        SPECIAL = 6
    }
    public static string GetDescription(this Enum enumValue)
    {
        var fi = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return (attributes != null && attributes.Length > 0)
                    ? attributes[0].Description
                    : enumValue.ToString();
    }

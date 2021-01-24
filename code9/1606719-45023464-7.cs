    private static char defaultMaskChar = 'X';
    private static MaskOption defaultMaskOption = MaskOption.InTheMiddleOfString;
    private static int defaultPercentToApply = 25;
    public static string MaskChars(this string input)
    {
        return MaskChars(input, defaultMaskChar);
    }
    public static string MaskChars(this string input, char maskChar)
    {
        return MaskChars(input, maskChar, defaultPercentToApply);
    }
    public static string MaskChars(this string input, int percentToApply)
    {
        return MaskChars(input, defaultMaskChar, percentToApply);
    }
    public static string MaskChars(this string input, MaskOption maskOption)
    {
        return MaskChars(input, defaultMaskChar, defaultPercentToApply, maskOption);
    }
        
    public static string MaskChars(this string input, char maskChar, int percentToApply)
    {
        return MaskChars(input, maskChar, percentToApply, defaultMaskOption);
    }
    public static string MaskChars(this string input, char maskChar, MaskOption maskOption)
    {
        return MaskChars(input, maskChar, defaultPercentToApply, maskOption);
    }
    public static string MaskChars(this string input, int percentToApply, MaskOption maskOption)
    {
        return MaskChars(input, defaultMaskChar, percentToApply, maskOption);
    }

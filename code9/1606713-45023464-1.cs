    public static string MaskChars(this string input, char maskChar, 
        int percentToApply, MaskOption maskOptions)
    {
        var result = input.Trim();
        if (result.Length == 0 || percentToApply < 1) return result;
        if (percentToApply >= 100) return new string(maskChar, result.Length);
        var mask = new string(maskChar, 
            Math.Max((int)Math.Round(percentToApply * result.Length / 100m), 1));
        switch (maskOptions)
        {
            case MaskOption.AtTheBeginingOfString:
                result = mask + result.Substring(mask.Length);
                break;
            case MaskOption.AtTheEndOfString:
                result = result.Substring(0, result.Length - mask.Length) + mask;
                break;
            case MaskOption.InTheMiddleOfString:
                var half = (result.Length - mask.Length) / 2;
                result = result.Substring(0, half) + mask + result.Substring(half + mask.Length);
                break;
        }
        return result;
    }

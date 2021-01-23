    public static string FormatToUsableDateTime(string DateToConvert)
    {
        convertedDateTime = null;
        char chartocheck = DateToConvert.Contains('+') ? '+' : '-';
        int index = DateToConvert.IndexOf(chartocheck);
        convertedDateTime = (index > 0 ? DateToConvert.Substring(0, index) : "");
        return convertedDateTime;
    }

    static DateTime Parse(string input)
    {
        CultureInfo ci =
            CultureInfo.CreateSpecificCulture(
                input.Contains(".") ?
                    "en-GB" :
                    "en-US");
        DateTime result;
        DateTime.TryParse(input, ci, DateTimeStyles.None, out result);        
        return result;
    }

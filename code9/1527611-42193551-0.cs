    public static T Translate<Q, T>(this Q inputNumber) {
        string value = TypeDescriptor.GetConverter(typeof(Q)).ConvertToString(inputNumber);
        string replacedValue = value.ToString()
            .Replace("１", "1")
            .Replace("２", "2")
            .Replace("３", "3")
            .Replace("４", "4")
            .Replace("５", "5")
            .Replace("６", "6")
            .Replace("７", "7")
            .Replace("８", "8")
            .Replace("９", "9")
            .Replace("０", "0");
        return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(replacedValue);
    }

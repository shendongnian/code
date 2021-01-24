    private static string GetEnumDescription(string text)
    {
        var valueAttribs = typeof(Values).GetMember(text)[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        return ((DescriptionAttribute)valueAttribs[0]).Description;
    }

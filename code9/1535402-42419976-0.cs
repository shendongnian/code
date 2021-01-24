    public static string ToSentenceCase(this string str)
    {
        var temp = Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        return Regex.Replace(temp, "^rma.", m => m.Value.Substring(0, 3).ToUpper() + " " + char.ToUpper(m.Value[3]), RegexOptions.IgnoreCase);
    }

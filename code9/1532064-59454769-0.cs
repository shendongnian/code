cs
public static class StringExtensions
{
    public static string ToCamelCase(this string str)
    {
        bool hasValue = !string.IsNullOrEmpty(str);
        // doesn't have a value or already a camelCased word
        if (!hasValue || (hasValue && Char.IsLower(str[0])))
        {
            return str;
        }
        string finalStr = "";
        int len = str.Length;
        int idx = 0;
        char nextChar = str[idx];
        while (Char.IsUpper(nextChar))
        {
            finalStr += char.ToLowerInvariant(nextChar);
            if (len - 1 == idx)
            {
                // end of string
                break;
            }
            nextChar = str[++idx];
        }
        // if not end of string 
        if (idx != len - 1)
        {
            finalStr += str.Substring(idx);
        }
        return finalStr;
    }
}
Use it like this:
cs
string camelCasedDob = "DOB".ToCamelCase();

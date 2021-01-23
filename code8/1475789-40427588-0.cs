    public static string ReverseString2(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        //for (int i = 0, j = str.Length - 1; i < j; i++, j--)
        //{
        //    char c = chars[i];
        //    chars[i] = chars[j];
        //    chars[j] = c;
        //}
        return new string(chars);
    }

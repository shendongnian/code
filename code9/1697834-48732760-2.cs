    public static String RemoveChars(this String input, params Char[] chars)
    {
        StringBuilder builder = new StringBuilder();
        for (Int32 i = 0; i < input.Length; ++i)
        {
            if (!chars.Contains(input[i]))
                builder.Append(input[i]);
        }
        return builder.ToString();
    }
    text = text.RemoveChars(replacements);

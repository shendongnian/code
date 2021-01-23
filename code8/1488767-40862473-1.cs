    public static string Replace(this string str, char find, string replacement)
    {
        StringBuilder result = new StringBuilder(str.Length); // initial capacity
        int pointer = 0;
        int index;
        while ((index = str.IndexOf(find, pointer)) >= 0)
        {
            // Append the unprocessed data up to the character
            result.Append(str, pointer, index - pointer);
            // Append the replacement string
            result.Append(replacement);
            // Next unprocessed data starts after the character
            pointer = index + 1;
        }
        // Append the remainder of the unprocessed data
        result.Append(str, pointer, str.Length - pointer);
        return result.ToString();
    }

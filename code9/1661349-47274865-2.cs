    public static IEnumerable<int> ExtractNumbers(string text)
    {
        text += " ";  // to handles cases where numbers are in the last position of the string
        var temp = string.Empty;
        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i]))
            {
                if ('-'.Equals(text[i - 1]))
                {
                    temp += text[i - 1];
                }
                temp += text[i];
            }
            else if (temp.Length > 0)
            {
                yield return int.Parse(temp);
                temp = string.Empty;
            }
        }
    }

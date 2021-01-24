    var text = "-12 on the same day";
    public string ExtractNumbers(string text)
    {
        var result = string.Empty;
        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i]))
            {
                if ('-'.Equals(text[i - 1]))
                {
                    result += text[i - 1];
                }
                result += text[i];
            }
        }
        return result;
    }

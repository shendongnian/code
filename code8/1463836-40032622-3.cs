    static string Unescape(string str)
    {
        StringBuilder builder = new StringBuilder();
        int startIndex = 0;
        while(true)
        {
            int index = IndexOfBackslashU(str, startIndex);
            if (index == -1)
                return builder.Append(Regex.Unescape(str.Substring(startIndex))).ToString();
            builder.Append(Regex.Unescape(str.Substring(startIndex, index - startIndex)));
            string number = str.Substring(index + 2, 8);
            builder.Append(char.ConvertFromUtf32(int.Parse(number, NumberStyles.HexNumber)));
            startIndex = index + 10;
        }
    }
    static int IndexOfBackslashU(string str, int startIndex)
    {
        while (true)
        {
            int index = str.IndexOf(@"\U", startIndex);
            if (index == -1)
                return index;
            bool evenNumberOfPreviousBackslashes = true;
            for (int k = index-1; k >= 0 && str[k] == '\\'; k--)
                evenNumberOfPreviousBackslashes = !evenNumberOfPreviousBackslashes;
            if (evenNumberOfPreviousBackslashes)
                return index;
            startIndex = index + 2;
        }
    }

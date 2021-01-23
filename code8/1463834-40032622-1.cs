    static string Unescape(string str)
    {
        int k0 = 0, k = str.IndexOf(@"\U");
        while (k >= 0)
        {
            bool evenNumberOfPreviousBackslashes = true;
            int i = k - 1;
            while (i >= 0 && str[i] == '\\')
            {
                evenNumberOfPreviousBackslashes = !evenNumberOfPreviousBackslashes;
                i--;
            }
            if (evenNumberOfPreviousBackslashes)
            {
                string number = str.Substring(k + 2, 8);
                string decoded = char.ConvertFromUtf32(int.Parse(number, NumberStyles.HexNumber));
                string prefix = Regex.Unescape(str.Substring(0, k)) + decoded;
                str = prefix + str.Substring(k + 10);
                k = prefix.Length;
            }
            else
                k++;
            k0 = k;
            k = str.IndexOf(@"\U", k);
        }
        return str.Substring(0, k0) + Regex.Unescape(str.Substring(k0));
    }

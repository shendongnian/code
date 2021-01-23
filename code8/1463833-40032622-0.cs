    static string Unescape(string str)
    {
        int k = str.IndexOf(@"\U");
        while (k >= 0)
        {
            bool evenNumberOfPreviousBackslashes = true;
            int i = k - 1;
            while (i >= 0 && str[i] == '\\')
            {
                evenNumberOfPreviousBackslashes = !evenNumberOfPreviousBackslashes;
                i--;
            }
            if(evenNumberOfPreviousBackslashes)
            {
                string number = str.Substring(k + 2, 8);
                string decoded = char.ConvertFromUtf32(int.Parse(number, NumberStyles.HexNumber));
                str = str.Substring(0, k) + decoded + str.Substring(k + 10);
                k += decoded.Length;
            }
            else
                k++;
            k = str.IndexOf(@"\U", k);
        }
        return Regex.Unescape(str);
    }

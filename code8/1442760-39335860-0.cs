    static string \u0061lphaChange(string s)
    {
        int shift = 0;
        int shiftCount = 0;
        var ca = new char[s.Length];
        for (int i = s.Length - 1; i >= 0; i--)
        {
            var c = s[i];
            if ('0' <= c && c <= '9')
                shiftCount++;
            else
            {
                if (shiftCount > 0)
                {
                    int.TryParse(s.Substring(i + 1, shiftCount), out shift);
                    shift = shift % 26;
                    shiftCount = 0;
                }
                int max = 'Z';
                if ('a' <= c && c <= 'z') max = 'z';
                else if (c < 'A' || c > 'Z') continue; // optional just in case 
                var a = c + shift;
                if (a > max) a -= 26;
                ca[i] = (char)a;
            }
        }
        return new string(ca).Replace("\0", ""); // should be a bit faster than StringBuilder
    }

    public static IEnumerable<char> AsReverseEnumerable(this string s) {
        var chars = s.ToCharArray();
        for (var pos = s.Length-1; pos >= 0; --pos)
            yield return chars[pos];
    }
    private int getIntPattern(string text) => Convert.ToInt32("0"+new string(text.AsReverseEnumerable().Where(ch => Char.IsDigit(ch)).Take(2).Reverse().ToArray()));

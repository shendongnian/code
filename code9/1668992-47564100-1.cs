    public static string Reverse(string text) {
        if (text.Length <= 1) // base case
            return text;
        else // recursive case
            return Reverse(text.Substring(1))+text.Substring(0, 1);
    }

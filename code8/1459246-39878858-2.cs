    public static string CreateRandomSentence(int sizeOfString)
    {
        var sb = new StringBuilder();
        while (sb.Length < sizeOfString)
        {
            int wordLength = random.Next(8) + 1;
            sb.Append(CreateRandomString(wordLength)).Append(" ");
        }
        sb.Length = sizeOfString;
        return sb.ToString();
    }
    public static string CreateRandomString(int sizeOfString)
    {
        const string chars = "AbCDeFgHI12345678";
        var randomChars =
            InitInfinite(() => chars[random.Next(chars.Length)])
                .SkipWhile(c => c == ' ')
                .Take(sizeOfString);
        return new string(randomChars.ToArray());
    }
    public static IEnumerable<T> InitInfinite<T>(Func<T> selector)
    {
        while (true)
        {
            yield return selector();
        }
    }
    private static Random random = new Random();

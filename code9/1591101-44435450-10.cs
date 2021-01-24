    private static string GetRandomStringSB(int length)
    {
       var stringBuilder = new StringBuilder(length);
       var possibleLetters = "abcdefghijklmnopqrstuvwxyz";
       for (int i = 0; i < length; i++)
       {
           stringBuilder.Append(possibleLetters[r.Next(0, possibleLetters.Length - 1)]);
       }
       return stringBuilder.ToString();
    }

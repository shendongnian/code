    private static Random random = new Random();
    public static string GetRandomString(int length)
    {
        var chars = new char[length];
        var possibleLetters = "abcdefghijklmnopqrstuvwxyz";        
        for (int i = 0; i < length; i++)
        {
            chars[i] = possibleLetters[random.Next(0, possibleLetters.Length - 1)];
        }
        return new string(chars);
    }

    private static bool vowel(string word)
    {
        if (word == null) return false;
        char[] wordChar = word.ToUpper().ToCharArray();
        for (int i = 0; i < word.Length; i++)
        {
            switch (word[i])
            {
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                    return true;
                    break;
            }
        }
        Console.WriteLine("Word must contain a vowel");
        return false;
    }

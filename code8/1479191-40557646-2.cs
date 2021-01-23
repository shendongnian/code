    static void Main(string[] args)
    {
        long count = countCharacters("aba", 'a', 10);
        Console.WriteLine("Count is {0}", count);
        Console.WriteLine("Press ENTER to exit...");
        Console.ReadLine();
    }
    private static long countCharacters(string baseString, char c, long limit)
    {
        long result = 0;
        if (baseString.Length == 1)
        {
            result = baseString[0] == c ? limit : 0;
        }
        else
        {
            long n = 0;
            foreach (var ch in getInfiniteSequence(baseString))
            {
                if (n >= limit)
                    break;
                Console.WriteLine("{0}: {1}", n, ch);
                if (ch == c)
                {
                    result++;
                }
                n++;
            }
        }
        return result;
    }
    //This method iterates through a base string infinitely
    private static IEnumerable<char> getInfiniteSequence(string baseString)
    {
        int stringIndex = 0;
        while (true)
        {
            yield return baseString[stringIndex++ % baseString.Length];
        }
    }

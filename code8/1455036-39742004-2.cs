    static void Main(string[] args)
    {
        string HiddenWord = "csharp";
        //--make a dash array
        char[] dashes = new char[HiddenWord.Length];
        for (int i = 0; i < dashes.Length; i++)
        {
            dashes[i] = '_';
        }
        // --type dashes equal to array length
        for (int i = 0; i < dashes.Length; i++)
        {
            Console.Write(dashes[i] + "  ");
        }
        Console.WriteLine();
        int count = 0;
        Console.WriteLine(String.Join(" ", recursive2(HiddenWord, dashes, count)));
    }

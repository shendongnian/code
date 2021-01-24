    public static void Main()
    {
        string[] words = new[] { "Hello", "World", "in", "a", "frame" };
        var output = Recurse(words);
        String tabs = new string('*', output.Item2 + 4);
        Console.WriteLine(tabs);
        Console.WriteLine(output.Item1);
        Console.WriteLine(tabs);
        Console.ReadKey();
    }
    Tuple<string, int> Recurse(string[] words, int index = 0, int maxLength = 0)
    {
        maxLength = Math.Max(maxLength, words[index].Length);
        if (index < words.Length - 1)
        {
            var output = Recurse(words, index + 1, maxLength);
            maxLength = output.Item2;
            return Tuple.Create(
                string.Format("* {0} *{1}{2}", words[index].PadRight(maxLength), Environment.NewLine, output.Item1),
                maxLength);
        }
        return Tuple.Create(
            string.Format("* {0} *", words[index].PadRight(maxLength)),
            maxLength);
    }

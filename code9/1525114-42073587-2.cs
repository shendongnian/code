    static void Main(string[] args)
    {
        string firstString = "I am the first string";
        string secondString = "I am the second string";
        char delimiter = Convert.ToChar(" ");
        if (firstString.Equals(secondString))
        {
            Console.WriteLine("Both strings are equal");
            Console.ReadLine();
        }
        else
        {
            var firstStringArray = firstString.Split(delimiter);
            // ["I", "am", "the", "first", "string"]
            var secondStringArray = secondString.Split(delimiter);
            
            // ["I", "am", "the", "second", "string"]
            foreach (var word in firstStringArray)
            {
                if (Array.IndexOf(secondStringArray, word) == -1)
                {
                    // "first" is not found in secondStringArray, so print it to screen
                    Console.WriteLine(word);
                    Console.ReadLine();
                }
            }
        }
    }

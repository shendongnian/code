    static void Main(string[] args)
    {
        string firstString = "I am the first string";
        string secondString = "I am the second string";
        char delimiter = Convert.ToChar(" ");
        if (firstString.Equals(secondString))
        {
            Console.WriteLine("Both strings are equal");
        }
        else
        {
            var firstStringArray = firstString.Split(delimiter);
            var secondStringArray = secondString.Split(delimiter);
            foreach (var word in firstStringArray)
            {
                if (Array.IndexOf(secondStringArray, word) == -1)
                {
                    Console.WriteLine(word);
                    Console.ReadLine();
                }
            }
        }
    }

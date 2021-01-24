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
            var firstStringList = firstString.Split(delimiter).ToList();
            // ["I", "am", "the", "first", "string"]
            var secondStringList = secondString.Split(delimiter).ToList();
            
            // ["I", "am", "the", "second", "string"]
            foreach (var word in firstStringList)
            {
                if (secondStringList.IndexOf(word) == -1)
                {
                    var indexOfWord = firstStringList.IndexOf(word); // 3
                    secondStringList.Insert(indexOfWord, word); // Insert the word that was not found at position 3 inside secondStringList
                    // ["I", "am", "the", "first", "second", "string"]
                    // [ 0,    1,    2,      3,        4,         5  ]
                    Console.WriteLine(string.Join(" ", secondStringList));
                    // Join the secondStringList to make 1 string separated by the space character
                    Console.ReadLine();
                }
            }
        }
    }

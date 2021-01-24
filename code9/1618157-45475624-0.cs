    string longString = "word1, word2, word 3";
    List<string> myList = new List<string>(new string[] { "word4", "word 2", "word 3" });
    if (myList.Any(str => longString.Contains(str)))
    {
        Console.WriteLine("success!");
    }
    else
    {
         Console.WriteLine("fail!");
    }

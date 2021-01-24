    public static void RemoveSpecifiedCharacters()
    {
        Console.WriteLine("\nWrite a word/sentence: ");
        string myString = Console.ReadLine();
        Console.Write("Type the character you would like to replace: ");
        string myCharacter = Console.ReadLine();
        List<int> findIndex = new List<int>();
        int offs = 0;
        while (offs < myString.Length)
        {
          offs = myString.IndexOf(myCharacter, offs);;
          if (offs == -1)
            break;
          findIndex.Add(offs);
          offs++;
        }
        for (int i = 0; i < findIndex.Count; i++)
        {
            Console.Write(findIndex[i]);
        }           
    }

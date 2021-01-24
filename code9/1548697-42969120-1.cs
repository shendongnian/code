    public static void TestPalin()
    {
       // This method prompts the user for a word and a letter.
       // It then determines whether or not the word is a palindrome and the number of times the letter appears in the palindrome.
       //
       Console.WriteLine("Enter a word: ");
       string word = Console.ReadLine(); // Read in the word from the console.
       Console.WriteLine("Enter a letter: ");
       char letter = Console.ReadLine()[0]; // Read in the specified letter from the console.
       int letterCount;
       string reverseWord = ReverseAndGetCharCount(word, letter, out letterCount);
       IsPalin(word, reverseWord, letter, letterCount);
       Console.ReadLine();
    }
    public static void IsPalin(string word, string reverseWord, char letter, int letterCount)
    {
       // This method is used to display the result of the TestPalin method.
       //
       if (word == reverseWord)
          Console.WriteLine($"The word {word} is a palindrome");
       else
          Console.WriteLine($"The word {word} is not a palindrome");
       Console.WriteLine($"The letter {letter} appeared {letterCount} times within the word");
    }
    public static string ReverseAndGetCharCount(string s1, char selectedChar, out int countChar)
    {
       // This method reverses a string and counts the number of times the selected letter appears in the word.
       //
       char[] charArray = s1.ToCharArray();
       char[] reverseArray = new char[s1.Length];
       countChar = 0;
       int j = 0;
       char c;
       for (int i = s1.Length - 1; i >= 0; i--)
       {
          c = charArray[i];
          reverseArray[j++] = c;
          if (c == selectedChar)
             countChar++;
       }
       return new string(reverseArray);
    }

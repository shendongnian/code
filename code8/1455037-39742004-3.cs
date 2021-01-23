    public static char[] recursive2(string HiddenWord, char[] dashes)
    {
        // do only if the are Any dashes in the array
        if (dashes.Any(x=>x == '_'))
        {                
            Console.WriteLine("Enter a letter");
            char letter = char.Parse(Console.ReadLine());
            
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                //replace dash with letter
                //if correct letter put dash instead of letter ELSE put old character
                dashes[i] = HiddenWord[i] == letter ? letter : dashes[i];
            }
            //display again dash with letters instead
            Console.Write(String.Join(" ", dashes) + Environment.NewLine);
         
            // here happens the recursion! call the same method with the newly
            // changed parameters
            return recursive2(HiddenWord, dashes);
        }
        else
        {
            return "\nCongratulations!".ToCharArray();
        }
    }

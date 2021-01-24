    while (guess != secretarray.Length)
    {
        Console.WriteLine();
        Console.Write("Enter a letter: ");
        letter = Convert.ToString(Console.ReadLine());
        bool correct = false;
        for (int i = 0; i < secretarray.Length; i++)
        {
            if (secretarray[i] == letter)
            {
                guessarray[i] = letter;
                guess++;
                correct = true;
            }
         }
         
         if (guess != 0)
         {
             foreach (string s in guessarray)
             {
                Console.Write(s + " ");
             }
          }
          else if (!correct)
          {
             Console.WriteLine("There is no letter like that!");
          }
          counter++;
    }

    class Program
    {
        static string HiddenWord = "";
        static char[] dashes;
        static void Main(string[] args)
        {
            HiddenWord = "csharp";
            dashes = new char[HiddenWord.Length];
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
            //--ask the user to guess
            askUserToGuess(count);
            Console.ReadLine();
        }
        private static void askUserToGuess(int count)
        {
            Console.WriteLine("Enter a letter");
            char letter = char.Parse(Console.ReadLine());
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                //replace dash with letter
                if ((HiddenWord[i] == letter) && (dashes[i] != letter))
                {
                    count++; //update the count to check when to exit
                    dashes[i] = letter;  //if correct letter put dash instead of letter
                    //display again dash with letters instead
                    for (int j = 0; j < dashes.Length; j++)
                    {
                        Console.Write(dashes[j] + " ");
                    }
                }
            }
            if (count < dashes.Length) askUserToGuess(count);
        }
    }

            string secretword = "m a n a m e j e f f";
            string[] secretarray = secretword.Split(' ');
            string letter = "";
            string[] guessarray = new string[secretarray.Length];
            int counter = 0;
            int guess = 0;
            bool goodguess = false;
            for (int i = 0; i < guessarray.Length; i++)
            {
                guessarray[i] = "_";
            }
            foreach (string s in guessarray)
            {
                Console.Write(s + " ");
            }
            while (guess != secretarray.Length)
            {
                goodguess = false;
                Console.WriteLine();
                Console.Write("Enter a letter: ");
                letter = Convert.ToString(Console.ReadLine());
                for (int i = 0; i < secretarray.Length; i++)
                {
                    if (secretarray[i] == letter)
                    {
                        guessarray[i] = letter;
                        guess++;
                        goodguess = true;
                    }
                }
                if (goodguess == true) 
                {
                    foreach (string s in guessarray)
                    {
                        Console.Write(s + " ");
                    }
                }
                else
                {
                    Console.WriteLine("There is no letter like that!");                   
                }
                counter++;
            }
            Console.WriteLine();
            Console.WriteLine("You guessd the word with tries: " + counter);
            Console.ReadLine();

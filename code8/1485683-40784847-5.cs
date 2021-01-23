        static void Main(string[] param)
        {
            //The list of Words which are anagrams
            List<string> solutions = new List<string>();
            //get the user input
            string userInput = "User writes arm ram kola like hi"; //Replace with Console.ReadLine().ToLower(); and don't forget to prompt the userwith input
 
            //split it into the diffrent words
            string[] words = userInput.Split(' ');
            //get the users "match want"
            string userMatchWant = "mar"; //Replace with Console.ReadLine().ToLower(); and don't forget to prompt the userwith input
            //Find words wich are as long as mar
            foreach (string word in words)
            {
                //if they arn't the same length it can't be an anagramm
                if (word.Length != userMatchWant.Length)
                    continue;
                //To Determin if all characters of the words are the same
                bool hasOnlyTheSameLetters = false;
                //now check if all characters contains
                foreach (char c in word)
                {
                    //If The lette is in the word assume it contains only of the letters that we are looking for, because
                    if (userMatchWant.Contains(c.ToString()))
                        hasOnlyTheSameLetters = true;
                    //else we know it has a different word so we can breack and check the other input words.
                    else
                    {
                        hasOnlyTheSameLetters = false;
                        break;
                    }                        
                }
                //if there is a diffrence in letters contine
                if (hasOnlyTheSameLetters == false)
                    continue;
                //else add the word to the solution
                else
                    solutions.Add(word);
            }
            
            //Print the solutions
            if(solutions.Count > 0)
            {
                Console.Write("Anagrams: ");
                foreach (string s in solutions)
                    Console.Write( s  + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

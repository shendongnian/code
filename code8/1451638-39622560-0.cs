    private static void clues(String clue)
        {
            
            string[] Words = new string[10];
            Words[5] = "apple";
            int idx = 5;
            char[] GuessHide = Words[idx].ToUpper().ToCharArray();
            char[] GuessShow = Words[idx].ToUpper().ToCharArray();
            for (int a = 0; a < GuessHide.Length; a++)
            {
                if (GuessShow[a] != Convert.ToChar(clue.ToUpper()))
                    GuessHide[a] = '*';
                else
                    GuessHide[a] = Convert.ToChar(clue.ToUpper());
            }
            Console.WriteLine(string.Join("", GuessHide));
        }

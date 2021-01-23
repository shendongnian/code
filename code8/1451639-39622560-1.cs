     private static void clues(string clue, char[] GuessHide, char[] GuessShow)
        {
            for (int a = 0; a < GuessHide.Length; a++)
            {
                if (GuessShow[a] == Convert.ToChar(clue.ToUpper()))
                {
                    GuessHide[a] = Convert.ToChar(clue.ToUpper());
                }
            }
            Console.WriteLine(string.Join("", GuessHide));
        }

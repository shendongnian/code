        string badLettersR1 = "qwertyuiop";
        string badLettersR2 = "asdfghjkl";
        string badLettersR3 = "zxcvbnm";
        string password = "Blablauio"; 
        for (int i = 0; i < password.Length-2; i++)
        {
            if (badLettersR1.Contains(password.Substring(i,3)) ||
                badLettersR2.Contains(password.Substring(i,3)) ||
                badLettersR3.Contains(password.Substring(i,3))) 
            {
                Console.WriteLine("password contains 3 consequtive letters in BadLetters");
            }
        }

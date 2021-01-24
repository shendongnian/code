        string badLetters = "qwertyuiopasdfghjklzxcvbnm";
        string password = "Blablauio"; 
        for (int i = 0; i < password.Length-2; i++)
        {
            if (badLetters.Contains(password.Substring(i,3))) 
            {
                Console.WriteLine("password contains 3 consequtive letters in BadLetters");
            }
        }

        string badLetters = "qwertyuiopasdfghjklzxcvbnm";
        string password = "Blablauio"; 
        for (int i = 0; i < password.length-2; i++)
        {
            if (badLetters.Contains(password.substring(i,3))) 
            {
                Console.WriteLine("password contains 3 consequtive letters in BadLetters");
            }
        }

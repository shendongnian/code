     private static void ReverseFirst()
        {
            Console.WriteLine("Reverse your name game!");
            Console.Write("Enter your first name: ");
            string firstName;
            firstName = Console.ReadLine();
            char[] reverseFirst = firstName.ToCharArray();
            Array.Reverse(reverseFirst);
            foreach(char i in reverseFirst)
            {
             Console.Write(i);
            }
        }

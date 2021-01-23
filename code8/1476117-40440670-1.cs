      static class Cinema
        {
            static void Main()
            {
                string[] titles = new string[] {"Rush", "How I Live Now", "Thor: The Dark World", "Filth", "Planes" };//array for the age requirements of each film
                int[] selection = new int[] { 15, 15, 12, 18, 0 };//array for the age requirements of each film
                int filmNumber; //parsed film number string 
                int age; //parsed age string
    
                Console.WriteLine("Welcome to our Multiplex.\n\nWe are presently showing:");
                for (int i = 0; i < titles.Length; i++)
                {
                    Console.WriteLine("{0}. {1} ({2})",i+1, titles[i],selection[i]);
                }
    
    
                filmNumber = GetIntNumber(1, 5, "\nEnter the number of the film you wish to see: ", "\nPlease enter a number between 1 and 5: ");
    
                //loops as long as input is not an integer
    
                age = GetIntNumber(0, 125, "\nEnter your age: ", "\nPlease enter an age between 0 and 125: ") - 1; 
                if (age < selection[filmNumber-1]) //if too young for the given film
                {
                    Console.WriteLine("\nAccess denied - you are too young");
                }
                else
                {
                    Console.WriteLine("\nPlease call our office at 888-999-2928 to reserve tickets.");
                }
                Console.ReadLine();
    
            }
    
            static int GetIntNumber(int min, int max, string prompt, string inputPrompt)
            {
                int number;
    
                Console.Write(prompt);
                do  //loops as long as input is not between 1 and 5
                {
                    Console.Write(inputPrompt);
                    while (!int.TryParse(Console.ReadLine(), out number)) //loops as long as the input is not an integer
                    {
                        Console.Write("\nYou must enter an integer number!");
                    } 
                } while (number < min || number >max);
                return number;
            }

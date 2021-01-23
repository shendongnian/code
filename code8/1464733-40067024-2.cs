    static void Main()
     {
         Console.Write("Enter a number between 1-10");
         var input = Console.ReadLine();
         var number = Convert.ToInt32(input);
         if (number >= 1 && number <= 10)
         {
             Console.WriteLine("Valid");
         }
         else
         {
            Console.WriteLine("Invalid");
         }
     }

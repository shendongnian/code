    public class Employ
    {
      public int income {get; set;}
      public int children {get; set}
      public int tax {get; set};
    
              public static void AskForIncome()
            {
                Console.WriteLine("What is your total income: ");
                string testNum = Console.ReadLine();
                bool dummyBool = int.TryParse(testNum, out income);
                if (dummyBool)
                {
                    Console.WriteLine();
                }
                else if (income < 0)
                {
                    Console.WriteLine("Your income cannot be negative.");
                }
                else
                {
                    Console.WriteLine("Enter your income as a whole-dollar numeric figure.");
                }
            }
            public static void NoChild()
            {
    
                Console.WriteLine("How many children do you have: ");
                string testChild = Console.ReadLine();
                bool dummyBool2 = int.TryParse(testChild, out children);
                if (dummyBool2)
                {
                    Console.WriteLine();
                }
                else if (children < 0)
                {
                    Console.WriteLine("You must enter a positive number.");
                }
                else
                {
                    Console.WriteLine("You must enter a valid number.");
                }
    
            }
            public static void CalculateTax()
            {
                tax = income - 10000 - (children * 2000);
                if (tax < 0)
                {
                    Console.WriteLine("You owe no tax.");
                }
                else
                {
                    Console.WriteLine("You owe a total of $" + tax + " tax.");
                }
            }
    }

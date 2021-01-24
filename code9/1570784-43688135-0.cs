    enum SIZE
    {
        SMALL,
        MEDIUM,
        LARGE
    }
    static void Main(string[] args)
    {
         float rTotalCost = 0.0f;
         string sUserDecision = string.Empty;
         do
         {
             SIZE UserChoice;
             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("Please Enter Your Choice: 1-Small, 2-Medium, 3-Large\n");
             UserChoice = (SIZE)int.Parse(Console.ReadLine());
             switch (UserChoice)
             {
                  case SIZE.SMALL:
                       rTotalCost += 2.50f;
                       break;
                  case SIZE.MEDIUM:
                       rTotalCost += 3.00f;
                       break;
                  case SIZE.LARGE:
                       rTotalCost += 3.50f;
                       break;
                  default:
                       Console.WriteLine("Your choise {0} Is Invalid", UserChoice);
                       break;
             }
             Console.WriteLine("\n\nDo You want to buy another coffee? Yes or No\n");
             sUserDecision = Console.ReadLine().ToUpper();
             if (sUserDecision != "YES" && sUserDecision != "NO")
             {
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("\n\nError! Invalid Selection Made! \n\n");
                 break;
             }
        } while (sUserDecision != "NO");
        Console.WriteLine("\n\nThank you for shopping!  Your total is:\t$" + rTotalCost);            
        }
    }

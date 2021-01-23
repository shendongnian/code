    int keypress; // Variable to hold number
    
    ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
    
    // We check input for a Digit
    if (char.IsDigit(UserInput.KeyChar))
    {
         keypress = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
    
         if (keypress == 1)
         {
             Console.WriteLine("6$ Cheese added to your cart");
         }
         else if (keypress == 2)
         {
             Console.WriteLine("2$ Bread added to your cart");
         }
         else if (keypress == 3)
         {
             Console.WriteLine("1$ cookie added to your cart");
         }
     }
     else
     {
          keypress = -1;  // Else we assign a default value
          Console.WriteLine("Number you entered isn't in the grocery list, please retry");
     }

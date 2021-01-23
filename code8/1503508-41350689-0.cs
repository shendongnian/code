    ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
                // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    keypress = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                    switch(keypress)
               {
                    case = 1:
                        Console.WriteLine("6$ Cheese added to your cart");
                    break;
                    case = 2:
                        Console.WriteLine("2$ Bread added to your cart");
                    break;
                    case = 3:
                    break;
                        Console.WriteLine("1$ cookie added to your cart");
                    
                    default:
                
                    keypress = -1;  // Else we assign a default value
                    Console.WriteLine("Number you entered isn't in the grocery list, please retry");
                    break;
                }
              }

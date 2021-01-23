         int num1, num2, output;
        string  op;
    
        Console.Write("\n\n");
        Console.WriteLine("Calculator\n");
        Console.WriteLine("=============");
        Console.Write("\n\n");
    
    Start:
    
        do
        {
            Console.Write("Please enter valid first number:");
        } while (!int.TryParse(Console.ReadLine(), out num1));
    
    
        do
        {
            Console.Write("Please enter valid second number:");
        } while (!int.TryParse(Console.ReadLine(), out num2));
    
        Operator:
    
        Console.WriteLine("Please select operator: ");
        Console.WriteLine("\nAddition : +");
        Console.WriteLine("Multiplication: *");
        Console.WriteLine("Division: /");
        Console.WriteLine("Subtraction: -");
        Console.Write("Enter Operator: ");
        op = Console.ReadLine();
    
    
    
    
        switch (op)
        {
            case "+":
                output = num1 + num2;
                Console.WriteLine("{0} added to {1} = {2}", num1, num2, output);
                break;
    
            case "*":
                output = num1 * num2;
                Console.WriteLine("{0} multiplied by {1} = {2}", num1, num2, output);
                break;
    
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero. Please try again");
                    goto Start;
    
                }
                else
                {
                    output = num1 / num2;
                    Console.WriteLine("{0} divided by {1} = {2}", num1, num2, output);
                    break;
                }
    
            case "-":
                output = num1 - num2;
                Console.WriteLine("{0} minus{1} = {2}", num1, num2, output);
                break;
    
            default:
                Console.WriteLine("You entered an invalid operator. Please try again\n");
                goto Operator;                     
    
         }
    
       Console.WriteLine("\nPress enter to continue....");
       Console.ReadLine();

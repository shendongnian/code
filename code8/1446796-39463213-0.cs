    Start:
        
    Console.Write("Please enter first number:");
    if (!int.TryParse(Console.ReadLine(), out num1))
        goto Start;
    //num1 = Convert.ToInt32(Console.ReadLine());
    
    
    Console.Write("Please enter second number: ");
    num2 = Convert.ToInt32(Console.ReadLine());
    
    Operator:
    
    ...

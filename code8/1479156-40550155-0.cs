    int? pin = null;
    int enteredPin;
    int realPin = 1111;
    while(pin != realPin)
    {
        if (pin.HasValue)
        {
            Console.Write("Wrong Password: ");
        }
        while(!int.TryParse(Console.ReadLine(), out enteredPin))
        {
            Console.Write("Please enter 4 numbers please: ");
        }
        pin = enteredPin;
    }

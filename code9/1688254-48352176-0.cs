    Console.Write("Hello, what is you name? ");
    var customer = Console.ReadLine();
    Console.WriteLine($"Nice to meet you, {customer}. What kind of pizza would you like?");
    
    var pizza = Console.ReadLine();
	
	if(pizza != "Sausage")
	{
    	Console.WriteLine("Make up your mind");
		return;
    }
	Console.WriteLine("Nice, that will be 20.00");

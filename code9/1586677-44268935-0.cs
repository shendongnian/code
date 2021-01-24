        Console.WriteLine("Welcome to Cylinders! \n Please type first the height of your cylinder and confirm with spacebar " + userInputHeight); // Welcomes the user and asks for the height
        string userInputHeight = Console.ReadLine(); // first userInput
        decimal h = Convert.ToDecimal(userInputHeight); // h for height
        Console.WriteLine("Please type now the radius of your cylinder and confirm with spacebar " + userInputRadius); // Asks the user for the radius  
        string userInputRadius = Console.ReadLine(); // second userInput 
        decimal r = Convert.ToDecimal(userInputRadius); // r for radius
        decimal V = Math.PI * r * 2 * 2 * h; // formular for volumue of a cylinder. Didn't know how to use the '^' sign. So I decided to use 2*2 instead.
        decimal SA = 2 * Math.PI * r * (r + h); // formular for the surface area of the cylinder.
        Console.WriteLine("The volume of your cylinder equals " + V + " and" + " the surface area equals " + SA); // this is where the magic happens.  
        Console.ReadKey(); // wait's for user input (in this case spacebar, but it doesn't matter which key is pressed)
        Console.WriteLine("That's it! Press any key to close."); // closes with any key the window

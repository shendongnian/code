    int input;
    while(true) {
        Console.WriteLine("Please enter a number");
        bool succeeds = Int32.TryParse(Console.ReadLine(), out input);
        if (!succeeds) {
            Console.WriteLine("Input Invalid! Try again!");
        } else {
            break;
        }
    }
    // make use of input here

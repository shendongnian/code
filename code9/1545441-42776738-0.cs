    void Method() {
        Console.WriteLine("This will always be printed no matter what happens.");
        if (stateA == 1) {
            if (stateB == 1) {
                Console.WriteLine("State 1");
                stateB = 2;
            }
            else {
                Console.WriteLine("State 2");
                stateA = 2;
            }
        }
        else {
            Console.WriteLine("Resetting States...")
            stateA = 1;
            stateB = 2;
        }
        Console.WriteLine("This will always also be printed no matter what happens.");
        Console.WriteLine("");
    }

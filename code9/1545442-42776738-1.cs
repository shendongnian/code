    void UpdateState() {
        if (stateA == 1 && stateB == 1) {
            Console.WriteLine("State 1");
            stateB = 2;
            return;
        }
        elseif (stateA == 1 && stateB == 2) {
            Console.WriteLine("State 2");
            stateA = 2;
            return;
        }
        else {
            Console.WriteLine("Resetting States...")
            stateA = 1;
            stateB = 2;
            return;
        }
    }
    void Method() {
        Console.WriteLine("This will always be printed no matter what happens.");
        UpdateState();
        Console.WriteLine("This will always also be printed no matter what happens.");
        Console.WriteLine("");
    }

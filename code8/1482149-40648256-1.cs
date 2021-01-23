    static void PrintError()
    {
        Console.WriteLine("You must enter a valid number between {0} and {1}, excluding 0", int.MaxValue, int.MinValue);
    }
    static void Main(string[] args)
    {
        try {
            int a = 10;
            int b = 0;
            PrintError(); // Tell user to enter valid numbers
            while (b == 0) {
                string user_input = Console.ReadLine();
                if (int.TryParse(user_input, out b)) { // is it an actual number?
                    if (b == 0) { // no 0's remember user!??
                        PrintError();
                    } else {
                        // ok, everything checks out, so do what the system can actually handle without throwing an error
                        Console.WriteLine("a/b = {0}", (a / b));
                    }
                } else {
                    PrintError();
                }
            }
        } catch (Exception ex) {
            Console.WriteLine("Something exceptional happened: {0}", ex);
        }
    }
    

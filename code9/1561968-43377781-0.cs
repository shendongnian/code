    static void Main(string[] args) {
      string userInput = "";
      while ((userInput = GetMainSelection()) != "x") {
        switch (userInput) {
          case "c1":
            Console.WriteLine("C1 Deposit Checking method");
            break;
          case "c2":
            Console.WriteLine("C2 Deposit Savings method");
            break;
          case "b1":
            Console.WriteLine("B1 View Balance Checking method");
            break;
          case "b2":
            Console.WriteLine("B2 View Balance Savings method");
            break;
          case "w1":
            Console.WriteLine("W1 Withdraw Checking method");
            break;
          case "w2":
            Console.WriteLine("W2 withdraw Savings method");
            break;
        }
        Console.WriteLine("Press Any Key to continue"); // <-- show what method was just used
        Console.ReadKey();
        Console.Clear();
      }
      Console.Write("Press any key to exit the program");
      Console.ReadKey();
    }
    private static string GetMainSelection() {
      string userInput = "";
      while (true) {
        Console.WriteLine("Select an option? \n VIEW BALANCE (B1) checking, (B2) saving \n DEPOSIT (C1) checking, (C2) saving \n WITHDRAW (W1) checking, (W2) saving. (X) to EXit");
        userInput = Console.ReadLine().ToLower();
        if (userInput == "b1" || userInput == "b2" || userInput == "c1" || userInput == "c2" || userInput == "w1" || userInput == "w2" || userInput == "x") {
          return userInput;
        }
        else {
          Console.Clear();
        }
      }
    }

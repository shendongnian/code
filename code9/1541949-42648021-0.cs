    static void Main(string[] args)
    {
        Console.WriteLine("Please choose your environment and Username to test from below");
        Console.WriteLine("Dev");
        Console.WriteLine("Stage");
        Console.WriteLine("Prod");
        string inputtedText = "";
        inputtedText = Console.ReadLine();
        if (inputtedText == "Dev") { Program.TestServer("DevMachine", "DevUser", "DevPass"); }
        if (inputtedText == "Stage") { Program.TestServer("StageMachine", "StageUser", "StagePass"); }
        if (inputtedText == "Prod") { Program.TestServer("ProdMachine", "ProdUser", "ProdPass"); }
    }
    static void TestServer (string ServerName, string UserName, string UserPassword)
    {
      //Use ServerName UserName and UserPassword
    }

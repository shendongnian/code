        var test = new YourMSTestClass();
        test.ClassInitialize(); // use if needed
        test.TestInitialize(); // use if needed
        test.YourTestMethod();
        test.TestCleanup(); // use if needed
        test.Dispose(); // use if needed
        Console.ReadLine(); // so the console window doesn't close

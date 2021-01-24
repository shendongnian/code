        Console.WriteLine("First Step");
        Task awaitableTask = OtherMethodAsync();
        Console.Writeline("Second step");
        await awaitableTask;
        Console.Writeline("4th Step");
    }
    Public async Task OtherMethodAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("Step 3");
    }

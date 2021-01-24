    using (var errorMessages = new StringBuilder("error processing :")) {
        foreach (var item in listrailcar)
        {
            errorMessages.append(string.Format("Railcar number : {0}" + " is " + "{1}", item.Item1, item.Item2));
        }
        Console.WriteLine(errorMessages);
    }

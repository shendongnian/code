    var db = new List<Transaction>
    {
        new Transaction { Transaction_id = 123, Item = "AKP", Description = "Startup" }, 
        new Transaction { Transaction_id = 45, Item = "RW", Description = "Starting" }
    }
    foreach (var transaction in db)
    {
        Console.WriteLine(transaction.Item);
    }

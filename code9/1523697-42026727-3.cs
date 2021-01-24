    static void Main()
    {
        var oldList = new List<Transaction>
        {
            new Transaction{ TransactionID = 1 },
            new Transaction{ TransactionID = 2 },
            new Transaction{ TransactionID = 3 },
            new Transaction{ TransactionID = 4 },
            new Transaction{ TransactionID = 5 },
        };
        var newList = new List<Transaction>
        {
            new Transaction{ TransactionID = 2 },
            new Transaction{ TransactionID = 4 },
        };
        var missing = oldList.Except(newList, new Comparer());
        foreach (var item in missing) // This prints "1", "3" and "5".
        {
            Console.WriteLine(item.TransactionID);
        }
    }

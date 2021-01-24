    Console.WriteLine("DueDate     Desc    Amount");
    foreach (var item in sample)
    {
        var dateString = item.DueDate != null
            ? item.DueDate.Value.ToString("MM-dd-yyyy")
            : string.Empty;
        Console.WriteLine(dateString.PadRight(12) + item.Desc + "     " + item.Amount);
    }

    public static void Main()
    {
        var currentDate = DateTime.Now; // Descriptive variable names
        var endDate = new DateTime(2017, 11, 17);
    
        double remainingDays = endDate.Subtract(currentDate).TotalDays; //TimeSpan stores everything in doubles instead of integers
    
        Console.WriteLine("Days left: {0}", remainingDays); // Use String.Format formatting
        Console.ReadLine(); // Use readline so that program only exists when ENTER is pressed
    }

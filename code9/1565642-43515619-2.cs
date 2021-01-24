    static void Main(string[] args)
    {
        var columnInput1 = new List<string>() { "LastName", "FName", "Id", "DOB", "Gender", "phonenumber", "mobilenumber", "country" };
        bool result1 = CheckIfAllColumnsArePresent(columnInput1);
        Console.WriteLine(result1);
        var columnInput2 = new List<string>() { "LastName", "FName", "Id", "DOB", "Gender", "mobilenumber", "country" };
        bool result2 = CheckIfAllColumnsArePresent(columnInput2);
        Console.WriteLine(result2);
    }
    private static bool CheckIfAllColumnsArePresent(List<string> columnInput)
    {
        var columnsNeeded = new List<string>() { "LastName", "FName", "Id", "DOB", "Gender", "phonenumber", "mobilenumber", "country" };
        foreach (var column in columnInput)
        {
            if (columnsNeeded.Contains(column))
                columnsNeeded.Remove(column);
        }
        return columnsNeeded.Count == 0 ? true : false;
    }

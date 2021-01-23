    DateTime date = new DateTime();
    string result = "";
    foreach (var item in list)
    {
        int year = int.Parse(item.Substring(5 , 4));
        int month = int.Parse(item.Substring(9, 2));
        int day = int.Parse(item.Substring(11, 2));
        DateTime currentDate = new DateTime(year, month, day);
        if (currentDate > date)
        {
            date = currentDate;
            result = item;
        }
    }
    Console.WriteLine(result);

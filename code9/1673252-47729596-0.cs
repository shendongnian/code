    static int[,] MonthCalendar(int year, int month, DayOfWeek firstWeekDay)
    {
        int daysInMonth = DateTime.DaysInMonth(year, month);
        DayOfWeek first = new DateTime(year, month, 1).DayOfWeek;
        int left = ((int)first - (int)firstWeekDay + 7) % 7;
        int[,] arr = new int[7, (left + daysInMonth + 6) / 7];
        for (int i = 0; i < daysInMonth; i++)
        {
            int a = left + i;
            arr[a % 7, a / 7] = i + 1;
        }
        return arr;
    }
    static void Test(int year, int month, DayOfWeek firstWeekDay)
    {
        string[] week = new string[]{ "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};
        Console.WriteLine(year + "-" + month);
        for (int i = (int)firstWeekDay; i < ((int)firstWeekDay + 7); i++)
        {
            Console.Write(" " + week[i % 7]);
        }
        Console.WriteLine();
        var arr = MonthCalendar(year, month, firstWeekDay);
        for (int y = 0; y < arr.GetLength(1); y++)
        {
            for (int x = 0; x < 7; x++)
            {
                Console.Write(arr[x, y].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }

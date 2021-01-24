    private static DateTime nightTimeStart = new DateTime(1, 1, 1, 23, 0, 0);
    private static DateTime nightTimeEnd = new DateTime(1, 1, 2, 6, 0, 0);
    private struct WorkHours
    {
        public int NightHours;
        public int DayHours;
    }
    private static WorkHours GetWorkHours(DateTime t1, DateTime t2)
    {
        WorkHours result = new WorkHours();
        for (DateTime i = t1; i < t2; i = i.AddHours(1))
        {
            if (i >= nightTimeStart && i < nightTimeEnd)
                result.NightHours++;
            else
                result.DayHours++;
        }
        return result;
    }
    static void Main(string[] args)
    {
        WorkHours result;
        result = GetWorkHours(new DateTime(1, 1, 1, 22, 0, 0), new DateTime(1, 1, 2, 8, 0, 0));
        Console.WriteLine("{0} hours night time, {1} hours normal",
            result.NightHours, result.DayHours);
        result = GetWorkHours(new DateTime(1, 1, 1, 23, 0, 0), new DateTime(1, 1, 2, 5, 0, 0));
        Console.WriteLine("{0} hours night time, {1} hours normal",
            result.NightHours, result.DayHours);
        result = GetWorkHours(new DateTime(1, 1, 1, 20, 0, 0), new DateTime(1, 1, 2, 4, 0, 0));
        Console.WriteLine("{0} hours night time, {1} hours normal",
            result.NightHours, result.DayHours);
        result = GetWorkHours(new DateTime(1, 1, 2, 4, 0, 0), new DateTime(1, 1, 2, 8, 0, 0));
        Console.WriteLine("{0} hours night time, {1} hours normal",
            result.NightHours, result.DayHours);
        result = GetWorkHours(new DateTime(1, 1, 1, 16, 0, 0), new DateTime(1, 1, 1, 22, 0, 0));
        Console.WriteLine("{0} hours night time, {1} hours normal",
            result.NightHours, result.DayHours);
        Console.ReadLine();
    }

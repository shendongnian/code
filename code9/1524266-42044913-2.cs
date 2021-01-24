     public static void test1()
     {
        DateTime now = DateTime.Now;
        string timetext = "2017-02-04 12:16PM";
        DateTime deptime = DateTime.Parse(timetext);
        Console.WriteLine("text time="+timetext);
        if (deptime.TimeOfDay < now.TimeOfDay)
        {
            Console.WriteLine("time is less than now");
        }
        Console.WriteLine("End");
        Console.ReadLine();
    }

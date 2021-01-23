    public void GetCurrentSchedule()
    {
        String JSONstring = File.ReadAllText("\\USER\\Schedule\\Schedule.txt");
        RootObject p1 = JsonConvert.DeserializeObject<RootObject>(JSONstring);
        string[] sDay = new string[i + 4];//Declare your array here (+4 becuase your for loop goes upto +3)
        for (int a = i; a <= (i + 3); a++)
        {
            sDay[a - i] = p1.schedulePeriods[a].day; // assign the value to  array element (a - i because if i > 0 because arrays start with 0)
            sPeriod = p1.schedulePeriods[a].periodType;
            sStart = p1.schedulePeriods[a].startTime;
            sCancel= p1.schedulePeriods[a].isCancelled;
            sHeat = p1.schedulePeriods[a].heatSetpoint;
            sCool = p1.schedulePeriods[a].coolSetpoint;
            sFan = p1.schedulePeriods[a].fanMode;
            Console.PrintLine("day: {0}", sDay[a - i]); // Call it with index
            Console.PrintLine("period: {0}", sPeriod);
            Console.PrintLine("start: {0}", sStart);
            Console.PrintLine("Cancel: {0}", sCancel);
            Console.PrintLine("Heat: {0}", sHeat);
            Console.PrintLine("Cool: {0}", sCool);
            Console.PrintLine("Fan: {0}", sFan);
        }
    }

    public static void WhichDaysAreTheyWorking()
    {
       List<String> daysOfTheWeek = new List<String>();
       daysOfTheWeek.Add("Monday");
       daysOfTheWeek.Add("Tuesday");
       daysOfTheWeek.Add("Wednesday");
       daysOfTheWeek.Add("Thursday");
       daysOfTheWeek.Add("Friday");
       daysOfTheWeek.Add("Saturday");
       daysOfTheWeek.Add("Sunday");
       int i = 0;
       for (int week = 1; week < 50; week++)
       {
          if (daysOfTheWeek[i].Equals("Friday"))
          {
              Console.WriteLine("Week # " + week + " They work " + daysOfTheWeek[i]);
              Console.WriteLine("Week # " + (week + 1) + " They work " + daysOfTheWeek[i - 4]);
              i = 2;
              week = week + 1;
              continue;
          }
          else
          {
              Console.WriteLine("Week # " + week + "They work " + daysOfTheWeek[i]);
              i = i + 2;
          }
       }
       Console.ReadKey();
    }

    public void WhichDaysAreTheyWorking()
    {
       List<String> days = new List<String>();
       days.Add("Monday");
       days.Add("Tuesday");
       days.Add("Wednesday");
       days.Add("Thursday");
       days.Add("Friday");
       days.Add("Saturday");
       days.Add("Sunday");
       int i = 0;
       for (int week = 0; week < 50; i++)
       {
         string day = days[i];
         if (day.Equals("Friday"))
         {
            i += 3;
            Console.WriteLine("They work " + days[i]);
            i = 0;     
         }
         Console.WriteLine("They work " + days[i]);
         i++;
       }
    
    }

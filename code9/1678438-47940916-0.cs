    public class BetweenTime
    {
        // list of lower and upper timespans
        static List<BetweenTime> BetweenTimes = new List<BetweenTime> {
          new BetweenTime("7:45:0", "8:5:0"),
          new BetweenTime("6:45:0", "7:5:0"),
          new BetweenTime("12:15:0", "12:35:0"),
          new BetweenTime("10:45:0", "11:5:0"),
          new BetweenTime("7:15:0", "7:35:0"),
        };
        
        // get correctedtime if it is found in the list
        public static string GetCorrectedTime(DateTime input)
        {
            var time =  input.TimeOfDay;
            // find the time in the list for lower and upper values
            // and return its corrected time
            var found = from dtm in BetweenTimes
                        where time >= dtm.Lower && time <= dtm.Upper 
                        select dtm.Upper.Add(new TimeSpan(0,-5,0));
     
            // if we have found at least one
            if (found.Count() != 0) 
            {
               // check we only have one result
               var difftime = found.Single();
               // add the A and correct the time
               return "A" + new DateTime(
                   input.Year,
                   input.Month,
                   input.Day,
                   difftime.Hours,
                   difftime.Minutes,
                   difftime.Seconds); 
            } 
            else 
            {
               // not found so just output what came in.
               return input.ToString();
            }
        }
        
        // constructors
        private BetweenTime(string lower, string upper)
           :this(TimeSpan.Parse(lower), TimeSpan.Parse(upper))
        {
        }
        private BetweenTime(TimeSpan lower, TimeSpan upper)
        {
           Lower = lower;
           Upper = upper;
        }
        // fields
        TimeSpan Lower;
        TimeSpan Upper;
    }

    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication57
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
            
        }
        public class Period
        {
            public static List<Period> periods = new List<Period>() {
                new Period() { Name = "Period1", Days =  new Workweek[] { Workweek.Monday, Workweek.Tuesday, Workweek.Wednesday, Workweek.Thursday, Workweek.Friday}, Holiday = false, Start = new TimeSpan(0,0,0), End = new TimeSpan(7,0,0)},
                new Period() { Name = "Period2", Days =  new Workweek[] { Workweek.Monday, Workweek.Tuesday, Workweek.Wednesday, Workweek.Thursday, Workweek.Friday}, Holiday = false, Start = new TimeSpan(7,0,0), End = new TimeSpan(20,0,0)},
                new Period() { Name = "Period3", Days =  new Workweek[] { Workweek.Monday, Workweek.Tuesday, Workweek.Wednesday, Workweek.Thursday, Workweek.Friday}, Holiday = false, Start = new TimeSpan(20,0,0), End = new TimeSpan(22,0,0)},
                new Period() { Name = "Period4", Days =  new Workweek[] { Workweek.Monday, Workweek.Tuesday, Workweek.Wednesday, Workweek.Thursday, Workweek.Friday}, Holiday = false, Start = new TimeSpan(22,0,0), End = new TimeSpan(24,0,0)},
                new Period() { Name = "Period5", Days =  new Workweek[] { Workweek.Saturday, Workweek.Sunday}, Holiday = false, Start = new TimeSpan(0,0,0), End = new TimeSpan(7,0,0)},
                new Period() { Name = "Period6", Days =  new Workweek[] { Workweek.Saturday, Workweek.Sunday}, Holiday = false, Start = new TimeSpan(7,0,0), End = new TimeSpan(22,0,0)},
                new Period() { Name = "Period7", Days =  new Workweek[] { Workweek.Saturday, Workweek.Sunday}, Holiday = false, Start = new TimeSpan(22,0,0), End = new TimeSpan(24,0,0)},
                new Period() { Name = "Period8", Days = null, Holiday = true, Start = new TimeSpan(0,0,0), End = new TimeSpan(24,0,0)},
            };
            public string Name { get; set; }
            public Workweek[] Days { get; set; }
            public bool Holiday { get; set; }
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
            public static string GetName(DateTime startTime, DateTime endTime, Boolean holiday)
            {
                string name = "";
                if (holiday)
                {
                    name = "Period8";
                }
                else
                {
                    foreach (Period period in periods)
                    {
                        Boolean dayMatch = period.Days.Select(x => x = (Workweek)(2 ^ (int)startTime.DayOfWeek)).Any();
                        if (dayMatch)
                        {
                            if ((startTime.TimeOfDay > period.Start) && (endTime.TimeOfDay < period.End))
                            {
                                name = period.Name;
                                break;
                            }
                        }
                    }
                }
                return name;
            }
        }
        public enum Workweek
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Saturday = 64
        }
        public class Work
        {
            public string Name { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
     
    }

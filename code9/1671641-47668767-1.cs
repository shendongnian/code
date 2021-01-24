      using System;
      using System.Collections.Generic;
      using System.Linq;
    
      static class DateTimeExtension
      {
        public static bool IsWeekend (this DateTime dt) 
            => dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
    
        public static Func<DateTime, bool> IsWeekend_2 = 
            dt => dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;    
      }
    
      class Program
      {
        Func<DateTime, bool> IsWeekend = dt => dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
    
        static void PrintDates (IList<DateTime> dts) => Console.WriteLine (string.Join ("", dts.Select (item => item.ToString () + "      Weekend: " + (item.IsWeekend () ? "Yes" : "No") + "\n"))) ;
        static Random r = new Random ();
        static void Main (string[] args)
        {
          // Data
          var dates = new List<DateTime> ();
          Enumerable.Range (0, 50)
              .ToList ()
              .ForEach (n => dates.Add (DateTime.Now.AddDays (n).AddHours(r.NextDouble() * 12)));
    
          // no weekends
          var datesWithoutWeekends = dates.Where (myDate => !myDate.IsWeekend ()).ToList ();
    
          // also no weekends
          var datesWithoutWeekends_2 = dates.Where (myDate => !DateTimeExtension.IsWeekend_2 (myDate)).ToList ();
    
          // still no weekends
          var datesWithoutWeekends_3 = dates.Where (myDate =>myDate.DayOfWeek != DayOfWeek.Sunday && myDate.DayOfWeek == DayOfWeek.Saturday).ToList ();
    
    
          PrintDates (dates);
          Console.WriteLine ();
          PrintDates (datesWithoutWeekends);
          Console.ReadLine ();
        }
      }
    

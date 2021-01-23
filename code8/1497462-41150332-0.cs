    using System;
    
    namespace DateObject
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime[] exDates = new DateTime[] {new DateTime(2017, 1, 1)};
                var dt = exDates[0].Date;
                
                //new date with a different time
                DateTime t = new DateTime(2017, 1, 1, 5, 30, 23);
                
                //compare the two for date part only --exclude the time in the comparision
                if (dt.Equals(t.Date))
                {
                    Console.WriteLine("Dates are the same without comparing the time");
                }
            }
        }
    }

    using System;
    
    public class StOv4
    {
        public static void Main()
        {
            // Time in question: 11/22/2016 05:20 AM with an offset of -06:00
            TimeSpan questionOffset = new TimeSpan(-6, 0, 0);
            DateTimeOffset questionTime = new DateTimeOffset(2016, 11, 22, 5, 20, 0, 0,
                questionOffset);
            Console.WriteLine("Time with {0} offset: {1}", questionOffset, questionTime);
            // "u" format specifier indicates string is to represent UTC time.
            Console.WriteLine("UTC time: {0}", questionTime.ToString("u"));
            
        }
    }

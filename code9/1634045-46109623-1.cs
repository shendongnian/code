    using System;
    
    namespace Test
    {
        public class Program
        {
            public static void Main()
            {
                var start = TimeSpan.Parse("20:00");
                var end = TimeSpan.Parse("08:00");
                var now = DateTime.Now.TimeOfDay;
    
                var flag = InTheTimeWindow(start, end, now);
    
                if (flag)
                {
                    var remainingTime = end - now;
    
                    if (remainingTime < TimeSpan.Zero)
                        remainingTime = remainingTime + new TimeSpan(24, 0, 0);
    
                    Console.WriteLine(remainingTime);
    
                }
                Console.ReadLine();
            }
    
            private static bool InTheTimeWindow(TimeSpan start, TimeSpan end, TimeSpan now)
            {
                var flag = false;
                if (start <= end)
                {
                    if (now >= start && now <= end)
                    {
                        flag = true;
                    }
                }
                else
                {
                    if (now >= start || now <= end)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
        }
    }

    using System;
    
    namespace StackOverflowProblem1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // input comes from user in form yyyyddMMTHHmmss
                DateTime offset = new DateTime(2016, 10, 12, 12, 22, 0);
                TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
                DateTimeOffset offsetConverted = new DateTimeOffset(offset, zone.GetUtcOffset(offset));
                DateTime roundTripOffset = offsetConverted.DateTime;
                Console.WriteLine("Input {0}, as DateTimeOffset {1},",
                      offset.ToString(),
                      offsetConverted.ToString());
                Console.WriteLine("after round trip {0}, Kind {1}.",
                     roundTripOffset,
                     roundTripOffset.Kind);
            }
        }
    }

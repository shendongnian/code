    using System;
    
    namespace StOv3
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime unspecifiedTime = new DateTime(2016, 12, 8, 0, 0, 0, DateTimeKind.Unspecified);
                DateTime localTime = new DateTime(2016, 12, 8, 0, 0, 0, DateTimeKind.Local);
                DateTime utcTime = new DateTime(2016, 12, 8, 0, 0, 0, DateTimeKind.Utc);
                Console.WriteLine("A DateTime, unspecified whether UTC or local {0}, Kind {1}", unspecifiedTime, unspecifiedTime.Kind);
                Console.WriteLine("A local DateTime {0}, Kind {1}", localTime, localTime.Kind);
                Console.WriteLine("A UTC DateTime {0}, Kind {1}", utcTime, utcTime.Kind);
                // Attempt to redefine variables with same values;
    
                unspecifiedTime = new DateTime(2016, 12, 8, 0, 0, 0, DateTimeKind.Unspecified);
                localTime = new DateTime(2016, 12, 8, 0, 0, 0, DateTimeKind.Local);
                utcTime = new DateTime(2016, 12, 8, 0, 0, 0, DateTimeKind.Utc);
                Console.WriteLine("A DateTime, unspecified whether UTC or local {0}, Kind {1}", unspecifiedTime, unspecifiedTime.Kind);
                Console.WriteLine("A local DateTime {0}, Kind {1}", localTime, localTime.Kind);
                Console.WriteLine("A UTC DateTime {0}, Kind {1}", utcTime, utcTime.Kind);
    
                // Attempt to change kind of variable
    
                unspecifiedTime = DateTime.SpecifyKind(unspecifiedTime, DateTimeKind.Utc);
                localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Unspecified);
                utcTime = DateTime.SpecifyKind(utcTime, DateTimeKind.Utc);
                Console.WriteLine("A DateTime, originally unspecified whether UTC or local {0}, Kind {1}",
                    unspecifiedTime, unspecifiedTime.Kind);
                Console.WriteLine("A DateTime, originally local {0}, Kind {1}", localTime, localTime.Kind);
                Console.WriteLine("A DateTime, originally UTC {0}, Kind {1}", utcTime, utcTime.Kind);
    
            }
        }
    }

    using System;
    using System.Device.Location;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                var a = new GeoCoordinate(41.507483, -99.436554);
                var b = new GeoCoordinate(38.504048, -98.315949);
                Console.WriteLine(a.GetDistanceTo(b)/1000.0);
            }
        }
    }

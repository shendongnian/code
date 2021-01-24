    using System;
    using System.Collections.Generic;
    using MoreLinq;
    namespace ConsoleApp1
    {
        public class Region
        {
            public string City     { get; set; }
            public int    PostCode { get; set; }
            public string WfRegion { get; set; }
            public override string ToString()
            {
                return  $"City:{City}, PostCode:{PostCode}, WfRegion:{WfRegion}";
            }
        }
        class Program
        {
            static void Main()
            {
                IEnumerable<Region> regions = new []
                {
                    new Region { City = "CityOne", PostCode = 1, WfRegion = "WfRegionOne"},
                    new Region { City = "CityOne", PostCode = 2, WfRegion = "WfRegionTwo"},
                    new Region { City = "CityTwo", PostCode = 3, WfRegion = "WfRegionOne"},
                    new Region { City = "CityOne", PostCode = 4, WfRegion = "WfRegionOne"},
                    new Region { City = "CityOne", PostCode = 5, WfRegion = "WfRegionThree"},
                    new Region { City = "CityTwo", PostCode = 6, WfRegion = "WfRegionOne"},
                    new Region { City = "CityTwo", PostCode = 7, WfRegion = "WfRegionThree"}
                };
                var result = regions.DistinctBy(x => (x.City, x.WfRegion));
                Console.WriteLine(string.Join("\n", result));
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var groupOptions = new List<GroupOption>();
                groupOptions.Add(new GroupOption { GroupName = 4.ToString() });
                groupOptions.Add(new GroupOption { GroupName = 5.ToString() });
                groupOptions.Add(new GroupOption { GroupName = 11.ToString() });
    
                var dataIndicators = new List<DataIndicator>();
                dataIndicators.Add(new DataIndicator { HeaderID = 4, IndicatorDescription = "four" });
                dataIndicators.Add(new DataIndicator { HeaderID = 99, IndicatorDescription = "ninetynine" });
                dataIndicators.Add(new DataIndicator { HeaderID = 100, IndicatorDescription = "onehundred" });
    
                Console.WriteLine("Before:");
                PrintGroupOptions(groupOptions);
    
                foreach (var dataIndicator in dataIndicators)
                {
                    foreach (var groupOption in groupOptions)
                    {
                        if (dataIndicator.HeaderID.ToString() == groupOption.GroupName)
                        {
                            groupOption.GroupName = dataIndicator.IndicatorDescription;
                        }
                    }
                }
    
                Console.WriteLine("After:");
                PrintGroupOptions(groupOptions);
            }
    
            static void PrintGroupOptions(List<GroupOption> groupOptions)
            {
                groupOptions.ToList().ForEach(g => Console.WriteLine(g));
            }
        }
    
        class GroupOption
        {
            public string GroupName { get; set; }
            public override string ToString()
            {
                return GroupName;
            }
        }
    
        class DataIndicator
        {
            public int HeaderID { get; set; }
            public string IndicatorDescription { get; set; }
        }
    }

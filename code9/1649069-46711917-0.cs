    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetCount1());
            Console.ReadLine();
        }
    static string GetCount1()
    {
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        FirstClass fc = new FirstClass
            {
                FirstList = new List<SecondClass>
                {
                    new SecondClass
                    {
                        SecondList = new List<ThirdClass>
                        {
                            new ThirdClass
                            {
                                ThirdList = new List<FisrtStruct>
                                {
                                    new FisrtStruct { Int1= 1, String1= "one" },
                                    new FisrtStruct{ Int1 = 2, String1= "two" },
                                    new FisrtStruct{ Int1= 3, String1 = "three" }
                                }
                            }
                        }
                    }
                }
            };
            foreach (var item in fc.FirstList)
            {
                foreach (var item2 in item.SecondList)
                {
                    foreach (var item3 in item2.ThirdList)
                    {
                        if (item3.Int1 > 1)
                        {
                            count1++;
                        }
                    }
                }
            }
        count2 = (from item in fc.FirstList from item2 in item.SecondList from item3 in item2.ThirdList select item3).Count(item3 => item3.Int1 > 1);
        // Solution:
        fc.FirstList
            .ForEach(f => fc.FirstList
                .ForEach(fl => fl.SecondList
                    .ForEach(sl => sl.ThirdList
                        .ForEach(tl =>
                        {
                            if (tl.Int1 > 1)
                            {
                                count3++;
                            }
                        }
                        ))));
        return "count1: " + count1 + " and count2: " + count2 + " and count3: " + count3;
        }
    }
    class FirstClass
    {
        internal List<SecondClass> FirstList { get; set; }
    }
    class SecondClass
    {
        public List<ThirdClass> SecondList { get; set; }
    }
    class ThirdClass
    {
        internal List<FisrtStruct> ThirdList { get; set; }
    }
    struct FisrtStruct
    {
        internal int Int1 { get; set; }
        internal string String1 { get; set; }
    }
    }

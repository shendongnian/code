    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication34
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> input = new List<string>() { "3.5.1_Patch", "3.5_CoreScript", "3.6_Patch", "3.6.1_Patch" };
                input.Sort((x,y) => new CustomSort() { s = x}.CompareTo(y));
            }
        }
        public class CustomSort : IComparable
        {
            public string s { get; set; }
            public int CompareTo(object input)
            {
                string[] thissplitArray = (s).Split(new char[] { '_' }).ToArray();
                string[] splitArray = ((string)input).Split(new char[] { '_' }).ToArray();
                if (thissplitArray[0] == splitArray[0])
                {
                    return thissplitArray[1].CompareTo(splitArray[1]);
                }
                else
                {
                    return thissplitArray[0].CompareTo(splitArray[0]);
                }
               
            }
        }
    }

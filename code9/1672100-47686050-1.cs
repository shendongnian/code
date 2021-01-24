    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] filenames = { "fg1a.12012017", "fg1b.12012017", "fg1c.12012017", "fg2a.12012017", "fg2b.12012017", "fg2c.12012017", "fg2d.12012017" };
                new SplitFileName(filenames);
                List<List<SplitFileName>> results = SplitFileName.GetGroups(); 
            }
        }
        public class SplitFileName
        {
            public static List<SplitFileName> names = new List<SplitFileName>(); 
            string filename { get; set; }
            string prefix { get; set; }
            string letter { get; set; }
            DateTime date { get; set; }
            public SplitFileName() { }
            public SplitFileName(string[] splitNames)
            {
                foreach(string name in splitNames)
                {
                    SplitFileName splitName = new SplitFileName();
                    names.Add(splitName);
                    splitName.filename = name;
                    string[] splitArray = name.Split(new char[] { '.' });
                    splitName.date = DateTime.ParseExact(splitArray[1],"MMddyyyy", System.Globalization.CultureInfo.InvariantCulture);
                    splitName.prefix = splitArray[0].Substring(0, splitArray[0].Length - 1);
                    splitName.letter = splitArray[0].Substring(splitArray[0].Length - 1,1);
                }
            }
            public static List<List<SplitFileName>> GetGroups()
            {
                return names.OrderBy(x => x.letter).GroupBy(x => new { date = x.date, prefix = x.prefix })
                    .Where(x => string.Join(",",x.Select(y => y.letter)) == "a,b,c,d")
                    .Select(x => x.ToList())
                    .ToList();
            }
        }
    }

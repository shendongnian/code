    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
               string[] inputs = { "v5.9.1.55", "v5.9.2.34", "v5.9.2.65",  "v5.9.5.12"};
                //demonstrates order by works
               string[] orderResults = inputs.OrderBy(x => new VersionSort(x)).ToArray();
                //sample test data to check class
               string[] testinputs = { "v4.9", "v5", "v5.9.1.2", "v5.9.2.65", "v5.10" };
                VersionSort testVersion = new VersionSort();
               foreach (string test in testinputs)
               {
                   string floor = testVersion.Floor(test, inputs);
                   Console.WriteLine("Version : '{0}', Floor : '{1}'", test, floor);
               }
               Console.ReadLine();
            }
        }
        public class VersionSort : IComparable 
        {
            int[] versionNumbers = null;
            public VersionSort() { }
            public VersionSort(string str)
            {
                //skip the first character v
                versionNumbers = str.Substring(1).Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
            }
            public int CompareTo(object other)
            {
                VersionSort version = (VersionSort)other;
                int minlength = versionNumbers.Length < version.versionNumbers.Length ? versionNumbers.Length : version.versionNumbers.Length;
                for (int i = 0; i < minlength; i++)
                {
                    if (versionNumbers[i] == version.versionNumbers[i]) continue;
                    return versionNumbers[i].CompareTo(version.versionNumbers[i]);
                }
                return versionNumbers.Length.CompareTo(version.versionNumbers.Length);
            }
            public string Floor(string compareVersionStr, string[] inputArray)
            {
                VersionSort compareversion = new VersionSort(compareVersionStr);
                VersionSort[] sortedVersions = inputArray.Select( x => new VersionSort(x)).OrderBy(x => x).ToArray();
                if(compareversion.CompareTo(sortedVersions[0]) == -1) return string.Empty;
                int index = 0;
                for (; index < sortedVersions.Length; index++ )
                {
                    int comparResults = compareversion.CompareTo(sortedVersions[index]);
                    if (comparResults == 0) return inputArray[index];
                    if (comparResults < 0) return inputArray[index - 1];
                }
                return inputArray.LastOrDefault();
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string[] arr ={"\\\\eZREUApp01.EU.abc.com\\eZR_Data\\ALSTOM GIS\\Review_Files",
                                "\\\\eZREUApp01.EU.abc.com\\eZR_Data\\ALSTOM GIS\\ADP_Processes",
                                "\\\\EZRSEARCH01.eu.abc.com\\road\\EZR_ALSTOM GIS_7\\",
                                "\\\\eZREUApp01.EU.abc.com\\eZR_Data\\ALSTOM GIS\\Production_Files\\009",
                                "\\\\EZRSEARCH01.EU.abc.com\\table\\EZR_Alstom_GIS_7\\",
                                "\\\\eZREUApp01.EU.abc.com\\eZR_Data\\ALSTOM GIS\\Production_Files"};
    
                string[][] newArr = new string[arr.Length][];
    
                for (int i = 0; i < newArr.GetLength(0); i++)
                {
                    newArr[i] = arr[i].Split(new char[] { '\\' },StringSplitOptions.RemoveEmptyEntries);
                }
    
                var min = newArr.Min(x => x.Length); 
    
                HashSet<string> resultSet = new HashSet<string>();
                foreach(var a in newArr)
                {
                    resultSet.Add("\\\\" + a.Take(3).Aggregate((x,y)=>x+"\\"+y));
                }
                foreach(var a in resultSet)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }

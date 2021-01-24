    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                new Mike2DDynamicData(FILENAME);
            }
        }
        public class Mike2DDynamicData
        {
            public static List<Mike2DDynamicData> data = new List<Mike2DDynamicData>();
            public int StepIndex;
            public DateTime Time;
            public int ElementID;
            public string SurfaceElevation;
            public string TotalWaterDepth;
            public string CurrentSpeed;
            public Mike2DDynamicData() { }
            public Mike2DDynamicData(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                
                string inputline = "";
                int lineNumber = 0;
                while((inputline = reader.ReadLine()) != null)
                {
                    if (++lineNumber > 1)
                    {
                        string[] splitArray = inputline.Split(new char[] { ',' });
                        Mike2DDynamicData newRow = new Mike2DDynamicData();
                        data.Add(newRow);
                        newRow.StepIndex = int.Parse(splitArray[0]);
                        newRow.Time = DateTime.Parse(splitArray[1]);
                        newRow.ElementID = int.Parse(splitArray[2]);
                        newRow.SurfaceElevation = splitArray[3];
                        newRow.TotalWaterDepth = splitArray[4];
                        newRow.CurrentSpeed = splitArray[5];
                    }
                }
            }
        
        
        
        }
    }

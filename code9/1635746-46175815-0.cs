      class Program
        {
    
            const string FSD_Identifier = "FSD:";
            const string FSD__Line_Identifier = "Drilling Data";
            
            const string Data_Start_Point_Identifier = "AVG_VOLTS";
           static readonly char[] splitter = {' ','\t'};
            static void Main(string[] args)
            {
               var result =  GetFileInfo("c:\\sample.txt");
            }
    
    
            private static MyFileInfo GetFileInfo(string path)
            {
    
                MyFileInfo info = new MyFileInfo();
                try
                {
                    
                    var lines = File.ReadAllLines(path);
                    var fsdLine  = lines.FirstOrDefault(line => line.Contains(FSD__Line_Identifier));
                    info.FSD =  fsdLine.Substring(fsdLine.IndexOf(FSD_Identifier) + FSD_Identifier.Length, 10); // take lenght you can specify or your own logic
                    var dataWithAvgVolts = lines.SkipWhile(line => !line.Contains(Data_Start_Point_Identifier)).ToList<string>();
    
    
                        if (dataWithAvgVolts.Count() > 1)
                        {
                            var data  =  dataWithAvgVolts[1].Split(splitter);
                            info.startvalue = Convert.ToDouble(data[0]);
                            data = dataWithAvgVolts[dataWithAvgVolts.Count-1].Split(splitter);
                            info.endvalue = Convert.ToDouble(data[0]);
                        }
    
                }
                catch (Exception ex)
                {
    
                    //logging here
                }
                return info;
            }
        }
    
        public class MyFileInfo
        {
    
            public string FSD;
            public double startvalue;
            public double endvalue;
    
        }

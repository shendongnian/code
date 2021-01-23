    using System;
    using System.IO;
    using System.Text;
    
    namespace ST_d1578e806c274e419063843a63f76441.csproj
    {
            public void Main()
            {
                String SomeFileName = @"C:\Users\unmsm_02\Desktop\ExampleTextFile.txt"; // Main FILE
                String AuxFileName = @"C:\Users\unmsm_02\Desktop\ResultTextFile.txt"; // File wher eis the result string
    
                using (FileStream fs = File.Open(SomeFileName, FileMode.Open))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    String line;
                    while (sr.EndOfStream == false)
                    {
                        line = sr.ReadLine();
                        if (line.Length > 1)
                        {
    
                            StringBuilder sb = new StringBuilder();
                            sb.Insert(0, "237");
                            sb.Insert(3, line);
                            sb.Insert(line.Length + 3, "#");
    
                            String line_Aux = sb.ToString();
                            
                            File.AppendAllText(AuxFileName, line_Aux + "\r\n");
                        }
                    }
                    
                    Dts.TaskResult = (int)ScriptResults.Success; //FORGET ABOUT THIS, its from the BIDS enviroment, just use the above, and it should work
                }
            }
        }
    }
     

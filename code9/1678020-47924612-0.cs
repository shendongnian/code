    var list = new List<string>;
    string xyz = "message";
    Console.WriteLine(xyz);
    list.add(xyz);
    foreach (object o in list)
    {
         StreamWriter sw = null;
                String Logfile = "C:\ExceptionLog.txt";
                if (!System.IO.File.Exists(LogFile))
                {
                    sw = File.CreateText(LogFile);
                    
                }
                else
                {
                    sw = File.AppendText(@"C:\ExceptionLog.txt");
                }
                sw.WriteLine(o);
                sw.Close();
    }
    

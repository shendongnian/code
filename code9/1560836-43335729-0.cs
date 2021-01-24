    string[] lineOutVar;
     List<string[]> lst_lineOutVar = new List<string[]>();
     using (StreamReader readerOne = new StreamReader("E:\\TEST\\sample.txt"))
     {
           string lineReader = readerOne.ReadLine();
           string[] lineOutput = lineReader.Split('\n');
           lineOutVar = lineOutput;
    
    
    
           while (readerOne.EndOfStream == false)
            {
                        lineOutVar = new string[1];
                        lineOutVar = readerOne.ReadLine().Split();
    
                        lst_lineOutVar.Add(lineOutVar);
    
                        //Console.WriteLine(lineOutVar[0]);
                    }
    
                    String getcontent = string.Empty;
                    foreach (var getLst in lst_lineOutVar)
                    {
                        getcontent = getcontent + "," + getLst[0].ToString();
                    }
    
    
                    Console.WriteLine(getcontent);
    
                }

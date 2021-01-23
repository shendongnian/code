    string[] clines = File.ReadAllLines("E:\\cprogram\\cpro\\bubblesort.c");
    List<string> list = new List<string>();
    int startIndexofcomm, endIndexofcomm;
            
     for (int i = 0; i < clines.Length ; i++ )
        {
           if (clines[i].Contains(@"/*"))
              {
                 startIndexofcomm = clines[i].IndexOf(@"/*");
                 list.Add(clines[i].Substring(0, startIndexofcomm));
                  
                 while(!(clines[i].Contains(@"*/")))
                 {
                    i++;
                 }
                    
                 endIndexofcomm = clines[i].IndexOf(@"*/");
                 list.Add(clines[i].Substring(endIndexofcomm+2));
                    
                 continue;
              }
              list.Add(clines[i]);
         }

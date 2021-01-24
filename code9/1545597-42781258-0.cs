      var lst = new List<string> { "jkl", "rueioqwp", "JKL:", "reqwdasf" };
    
       for (int i = 0; i < lst.Count; i++)
           {
                string newLine = "";
                if (i != lst.Count - 1)
                    newLine = Environment.NewLine;
                File.AppendAllText("c:\\temp\\tmp.txt", lst[i] + newLine);
            }

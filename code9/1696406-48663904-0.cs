    System.IO.File.WriteAllText(path + ".log", "<some text>,");
    
     // some lines of code here
    
    System.IO.File.AppendAllText(path + ".log", "<more text>");

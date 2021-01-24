      System.IO.StreamReader file =   
        new System.IO.StreamReader(@"c:\words.txt");  
        while((line = file.ReadLine()) != null)  
        {  
           string[] split = line.Split('=');
           string First = split[0] + " = ";
           string Second = split[1]; 
           //actually you can use split[0] and split[1], the two above llines are for demo
           counter++;  
        } 

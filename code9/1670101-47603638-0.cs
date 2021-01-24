    using (StreamReader sr = new StreamReader("maybyourfilepat\data.csv"))
    {
       string line = sr.ReadLine();
       //incase if you want to ignore the header
       while (line != null) 
       {
           string[] strCols = line.Split(',');
           line = sr.ReadLine();
       }
    }

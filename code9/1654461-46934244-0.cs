    List<string> outLines = new List<string>();
    
    while (reader.Read())
    {
       outLines.add(reader.GetValue(0).ToString() + "," +
                    reader.GetValue(1).ToString() + "," +
                    reader.GetValue(2).ToString());
    }
    
    System.IO.File.WriteAllLines("C:/outFile.csv",outLines.ToArray());

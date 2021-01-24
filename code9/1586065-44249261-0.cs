    string[] lines = File.ReadAllLines(filePath);
    
    using (StreamWriter writer = new StreamWriter(filePath))
    {
       for (int currentLineNmb = 0; currentLineNmb < lines.Length; currentLineNmb++ )
       {
           if (currentLineNmb == lineToEditNmb)
           {
              writer.WriteLine(lineToWrite);
              continue;
           }
           writer.WriteLine(lines[currentLineNmb]);                
       }
    }

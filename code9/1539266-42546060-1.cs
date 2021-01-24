    public static IEnumerable<string> TryGetLineIf(string filePath, Condition condition
    {
         StreamReader fileReader = new StreamReader(filePath);
         string currentLine = "";
     while (!fileReader.EndOfStream)
     {
        currentLine = fileReader.ReadLine();
        if (condition.MeetsCriteria(currentLine))
        {
             yield  return currentLine;
        }
     
        }
    } 

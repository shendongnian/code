    string filePath = @"C:\testFolder\newTestLog.txt";
    string[] allLines = File.ReadAllLines(filePath);
    for(int i = 0; i < allLines.Length; i++)
    {
        if (allLines[i].StartsWith("hello"))
        {
            allLines[i] += " salmon";
        }
    }
    File.WriteAllLines(filePath, allLines);

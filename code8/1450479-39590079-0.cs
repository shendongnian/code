    private static string[][] ReadAllLines(string filename)
    {
        string[] allFileLines = File.ReadAllLines(filename);
    
        string[][] arr = new string[allFileLines.Length][];
        for (int rowIndex = 0; rowIndex < allFileLines.Length; rowIndex++)
        {
            // Split by the space character and remove blank entries
            arr[rowIndex] = allFileLines[rowIndex].Split(new [] { ' ' },StringSplitOptions.RemoveEmptyEntries);
        }
        return arr;
    }

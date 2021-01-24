    public static FileData[] GetFileData(string firstFilePath, string secondFilePath)
    {
        // These guys hold the strongly typed version of the string values in the files
        int intHolder = 0;
        decimal decHolder = 0;
        // Get a list of ints from the first file
        var fileOneValues = File
            .ReadAllLines(firstFilePath)
            .Where(line => int.TryParse(line, out intHolder))
            .Select(v => intHolder)
            .ToArray();
        // Get a list of decimals from the second file
        var fileTwoValues = File
            .ReadAllLines(secondFilePath)
            .Where(line => decimal.TryParse(line, out decHolder))
            .Select(v => decHolder)
            .ToArray();
        // I guess the file lengths should match, but in case they don't, 
        // use the size of the smaller one so we have matches for all items
        var numItems = Math.Min(fileOneValues.Count(), fileTwoValues.Count());
        // Populate an array of new FileData objects
        var fileData = new FileData[numItems];
        for (var index = 0; index < numItems; index++)
        {
            fileData[index] = new FileData
            {
                File1Value = fileOneValues[index],
                File2Value = fileTwoValues[index]
            };
        }
        return fileData;
    }

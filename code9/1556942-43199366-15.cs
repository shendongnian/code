    public static DataFile Load(string[] allLines)
    {
        DataFile result = new DataFile();
        foreach (var line in allLines)
        {
            DataEntry entry = new DataEntry();
            
            var splittedValues = line.Split(',');
            entry.Station = splittedValues[0];
            entry.Year = splittedValues[1];
            entry.Number = splittedValues[2];
            entry.January = splittedValues[3];
            entry.February = splittedValues[4];
            entry.March = splittedValues[5];
            entry.April = splittedValues[6];
            entry.Mai = splittedValues[7];
            entry.Juni = splittedValues[8];
            entry.Juli = splittedValues[9];
            entry.August = splittedValues[10];
            entry.September = splittedValues[11];
            entry.October = splittedValues[12];
            entry.November = splittedValues[13];
            entry.December = splittedValues[14];
            result.Entries.Add(entry);
        }
        return result;
    }

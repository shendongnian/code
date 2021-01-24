    using System.IO;
    using System.Linq;
    ...
    string fileName = @"D:\Programming\Projects\Launch pad\itnol\KeySound";
    ...
    Dictionary<string, string> dict = File 
      .ReadLines(fileName)    
      .Where(line => line.Length >= 11)           // If you want to filter out lines 
      .ToDictionary(line => line.SubString(0, 6), // Key:   first 6 characters
                    line => line.SubString(6));   // Value: rest characters

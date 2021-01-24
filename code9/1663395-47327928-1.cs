    using System.IO;
    using System.Linq;
    ...
    Dictionary<string, string> dict = File 
      .ReadLines(@"C:\MyFile")                    //TODO: put the right name here
      .Where(line => line.Length >= 11)           // If you want to filter out lines 
      .ToDictionary(line => line.SubString(0, 6), // Key:   first 6 characters
                    line => line.SubString(6));   // Value: rest characters

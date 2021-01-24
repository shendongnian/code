    using System.IO;
    using System.Linq;
    ...
    Dictionary<string, string> dict = File 
      .ReadLines(@"C:\MyFile")                    //TODO: put the right name here
      .ToDictionary(line => line.SubString(0, 6),
                    line => line.SubString(6));

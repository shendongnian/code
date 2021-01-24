    using System.IO;
    using System.Linq;
    string[][] input = File.ReadAllLines(@"c:/theFilePath.txt")
                           .Select(x => x.Split(' '))
                           .ToArray();

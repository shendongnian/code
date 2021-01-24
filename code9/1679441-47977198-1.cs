    using System.IO;
    using System.Linq;
    ... 
    static void Main(string[] args) {
      string path = 
        @"C:\Users\scian\OneDrive\Documents\School\KS5\C#\Files\Adding to array from file.txt";
      List<string> fileArray = File
        .ReadLines(path)
        .Where(line => !string.IsNullOrWhiteSpace(line)) // If you want to remove empty lines
        .SelectMany(line => line.Split(new char[] { ' ', '\t'},
                                       StringSplitOptions.RemoveEmptyEntries))
        .ToList();
      ... 
    }

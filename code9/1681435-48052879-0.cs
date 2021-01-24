      using System.IO;
      using System.Linq;
      ...
     Student[] students = File
       .ReadLines("Students.csv")
       .Where(line => !string.IsNullOrWhiteSpace(line)) // Skip empty lines
       .Skip(1)  // Skip header
       .Select(line => line.Split(','))   
       .Select(items => new Student() {
          Name = items[0],
          Age = int.Parse(items[1]),
          City = items[2], })
       .ToArray();

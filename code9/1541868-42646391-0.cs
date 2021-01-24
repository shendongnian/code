     using System.Linq;
     
     ....
     List<Patient> patients = File
       .ReadLines("patients.txt")
       .Select(line => line.Split(','))
       .Select(items => new Patient(
          items[0],
          int.Parse(items[1]),
          int.Parse(items[2]), 
          int.Parse(items[3]),
          DateTime.ParseExact(items[4], "d/M/yyyy", CultureInfo.InvariantCulture)   
         ))
       .ToList();

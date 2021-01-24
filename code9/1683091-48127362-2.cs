    // needs: using System.Linq; in addition to using System;
    var any = false;
    var sum = 0l;
     
    Console.WriteLine(
        Console.ReadLine()
           .Split(' ')
           .Where(part => int.TryParse(part, out var _))
           .Aggregate("", (acc, part) =>
           {
               any = true;
               if (acc.Length > 0)
                   acc += " + ";
               acc += part;
    
               sum += int.Parse(part);
               return acc;
           }) + (any ? $" = {sum}" : "No valid numbers in input."));

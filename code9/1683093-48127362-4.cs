    // needs: using System.Linq; in addition to using System;
    var any = false;
    var sum = 0l;
     
    Console.WriteLine(                                    // write something
        Console.ReadLine()                                   // what you read via console input
           .Split(' ')                                       // thats being split by' '
           .Where(part => int.TryParse(part, out var _))     // only use things parsable as int
           .Aggregate("", (acc, part) =>   // for each thing you got, create a string starting
           {                               // with an empty string
               any = true;                 // remeber we had some valid input
               if (acc.Length > 0)         // already something in string? 
                   acc += " + ";                // add " + " to it
               acc += part;                // add the string that is parsable to int to result
    
               sum += int.Parse(part);     // it is parseable, so parse and add up
               return acc;                 // return what we have agg'ed so far to next cycle
           }) + (any ? $" = {sum}" : "No valid numbers in input."));
           // check if we got any, if so add sum to the console output, else the agg is ""
           // and we output our "error" message

    using System;
    using System.Linq;
    using System.Collections.Generic;
    List<string> Mksnos= { "Toyota", "Honda is Good", "Innova is very good" };
    List<string> GdsDscr= { "Toyota is a very good brand and it is costly",
                           "The carmaker's flagship sedan is now here in its hybrid avatar. It is brought to... The Honda Accord Hybrid has been launched in India" };
    var numberOfMissingValues = Math.Max(Mksnos.Count - GdsDscr.Count, 0);
    var paddedGdsDscr = GdsDscr.Concat(Enumerable.Range(0, numberOfMissingValues).Select(i => " ")).ToList();
    
    var lines = Mksnos.Zip(paddedGdsDscr, (make, comment) => $"{make}: {comment}");
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
    Console.ReadKey();

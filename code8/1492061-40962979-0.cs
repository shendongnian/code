    foreach (var iGroup in salesmen.GroupBy( iSalesman => iSalesman.NIVA1 )
                                    .OrderBy(aGroup => aGroup.Key))
    {
        Console.WriteLine("{0} salesmen have reached nivå {1}",
                           iGroup.Count,
                           iGroup.Key);
        Console.WriteLine("---------------SUMMARY--------------");
        foreach(var iSalesman in iGroup)
        {
            Console.WriteLine("Namn = {0} && Personnummer = {1} && Distrikt = {2} && AntalArtiklar = {3}",
                iSalesman.NAMN,
                iSalesman.PERSONNUMMER,
                iSalesman.DISTRIKT,
                iSalesman.ANTALARTIKLAR);
        }
        Console.WriteLine();
    }

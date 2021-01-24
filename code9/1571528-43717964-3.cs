        var db1 = new Data();
        foreach (var ke in db1.KillEvents.GroupBy)
        {
            System.Console.WriteLine("Ke {0}", ke.ToString());
        }
        foreach (var groupedBySide in db1.KillEvents.GroupBy(xx=>xx.killerSide))
        {
            System.Console.WriteLine("Side {0} has {1} kills ", groupedBySide.Key, groupedBySide.Count());
        }

    foreach (var group in groupedTiles)
    {
        Console.Out.WriteLine(group.Group);
        foreach (var tile in group.Tiles)
        {
            Console.Out.WriteLine("\t" + tile.Title);
        }
    }

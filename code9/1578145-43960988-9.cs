    var groupedTiles = tilesList
        .GroupBy(tile => tile.VisibleFace)
        // or .GroupBy(tile => tile, tileEqualityComparer)
        .SelectMany(grp => grp)
        .ToList();
    var combos = MultiCombinationsWithoutSorting(groupedTiles);
    // ...

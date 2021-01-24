    GroundTile[] grounds = FindObjectsOfType<GroundTile>();
    WallTile[] walls = FindObjectsOfType<WallTile>();
    // ... *same code but for other Classes* ...
    Tile[] tiles = FindObjectsOfType<Tile>();
    
    var groundsList = grounds.ToList();
    var wallsList = walls.ToList();
    var existingTiles = groundsList.Union(wallsList);
    
    var allTiles = tiles.ToList();
    tiles = allTiles.Where(a => existingTiles.Any(e => e.ID != a.ID)).ToArray();

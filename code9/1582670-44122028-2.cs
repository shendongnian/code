    GroundTile[] grounds = FindObjectsOfType<GroundTile>();
    WallTile[] walls = FindObjectsOfType<WallTile>();
    // ... *same code but for other Classes* ...
    Tile[] tiles = FindObjectsOfType<Tile>();
    
    var existingTiles = grounds.Union(walls);
    
    tiles = tiles.Where(t => existingTiles.All(e => e.ID != t.ID)).ToArray();

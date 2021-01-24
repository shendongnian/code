    public bool IsTileOfType<T>(ITilemap tilemap, Vector3Int position) where T : TileBase
    {
        TileBase targetTile = tilemap.GetTile(position);
    
        if (targetTile != null && targetTile is T)
        {
            return true;
        }
    
        return false;
    }

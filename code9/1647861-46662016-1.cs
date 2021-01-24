    public void findTilePoint()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                vector3 tilePosition = tilesArray[x,y].GetPosition()
                Debug.Log(tilePosition);
            }
        }
       // Debug.Log(x);
    }

    public Tile[,] tileArray;
    public Rectangle[,] tileCollisionArray;
    public Level()
        {
            CreateTileArray();
            tileArray = new Tile[byteArray.GetLength(0), byteArray.GetLength(1)];
            tileCollisionArray = new Rectangle[tileArray.GetLength(0), tileArray.GetLength(1)];
            CreateWorld();
            //here I convert the coördinates from the tiles to the collision rectangles
            for (int x = 0; x < tileArray.GetLength(0); x++) {
                for (int y = 0; y < tileArray.GetLength(1); y++) {
                    tileCollisionArray[x,y] = new Rectangle(tileArray[x,y].GetPosX, tileArray[x,y].GetPosY, tileArray[x,y].GetTileWidth, tileArray[x,y].GetTileHeight);
            }
        }

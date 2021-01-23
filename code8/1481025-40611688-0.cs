    //Given that the x value in the array is int x and the y value is int y
    //Assuming array is Tile[,] which has a .IsWalkable() method to check if you can move onto it
    public void ShowMoves(int x, int y, Tile[,] tiles, int movesLeft, bool[] blocks)
    {
        if(tiles.GetUpperBound(0) < x + 1)
        {
            if(tiles[x + 1, y].IsWalkable() && blocks[0])
            {
                /*Light up the tile*/
                if(movesLeft > 0)
                    ShowMoves(x + 1, y, tiles, movesLeft - 1, new bool[] { x != tiles.GetUpperBound(0), false, y != tiles.GetUpperBound(1), y != 0 });
            }
        }
        if(x - 1 >= 0)
        {
            if(tiles[x - 1, y].IsWalkable() && blocks[1])
            {
                /*Light up the tile*/
                if(movesLeft > 0)
                    ShowMoves(x - 1, y, tiles, movesLeft - 1, new bool[] { false, x != 0, y != tiles.GetUpperBound(1), y != 0 });
            }
        }
        if(tiles.GetUpperBound(1) < y + 1)
        {
            if(tiles[x, y + 1].IsWalkable() && blocks[2])
            {
                /*Light up the tile*/
                if(movesLeft > 0)
                    ShowMoves(x, y + 1, tiles, movesLeft - 1, new bool[] { x != tiles.GetUpperBound(0), x != 0, y != tiles.GetUpperBound(1), false });
            }
        }
        if(y - 1 >= 0)
        {
            if(tiles[x, y - 1].IsWalkable() && blocks[3])
            {
                /*Light up the tile*/
                if(movesLeft > 0)
                    ShowMoves(x, y - 1, tiles, movesLeft - 1, new bool[] { x != tiles.GetUpperBound(0), x != 0, false, y != 0 });
            }
        }
    }

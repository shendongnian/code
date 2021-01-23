    //I have now edited the code to better reflect your real data
    public void ShowMoves(Vector2 playerPosition, int diceNumber, bool[] blocks)
    {
        int x = (int)playerPosition.x;
        int y = (int)playerPosition.y;
        if(tileMap.GetUpperBound(0) < x + 1)
        {
            if(tileMap[x + 1, y].tag == "walkableGrid" && blocks[0])
            {
                /*Light up the tile*/
                if(diceNumber > 0)
                    ShowMoves(new Vector2(x + 1, y), diceNumber - 1, new bool[] { x != tileMap.GetUpperBound(0), false, y != tileMap.GetUpperBound(1), y != 0 });
            }
        }
        if(x - 1 >= 0)
        {
            if(tileMap[x - 1, y].tag == "walkableGrid" && blocks[1])
            {
                /*Light up the tile*/
                if(diceNumber > 0)
                    ShowMoves(new Vector2(x - 1, y), diceNumber - 1, new bool[] { false, x != 0, y != tileMap.GetUpperBound(1), y != 0 });
            }
        }
        if(tileMap.GetUpperBound(1) < y + 1)
        {
            if(tileMap[x, y + 1].tag == "walkableGrid" && blocks[2])
            {
                /*Light up the tile*/
                if(diceNumber > 0)
                    ShowMoves(new Vector2(x, y + 1), diceNumber - 1, new bool[] { x != tileMap.GetUpperBound(0), x != 0, y != tileMap.GetUpperBound(1), false });
            }
        }
        if(y - 1 >= 0)
        {
            if(tileMap[x, y - 1].tag == "walkableGrid" && blocks[3])
            {
                /*Light up the tile*/
                if(diceNumber > 0)
                    ShowMoves(new Vector2(x, y - 1), diceNumber - 1, new bool[] { x != tileMap.GetUpperBound(0), x != 0, false, y != 0 });
            }
        }
    }

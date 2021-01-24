    for(int y = 0; y < Height; y++)
    {
        for(int x = 0; x < Width; x++)
        {
            Tile currentTile = GetTile(x, y);
            if(!currentTile.IsWater)
                continue;
            Tile leftTile = GetLeftNeighbour(currentTile);
            Tile bottomTile = GetBottomNeighbour(currentTile);
            if(!leftTile.IsWater && !bottomTile.IsWater)
            {
                //first case
                Group newGroup = new Group();
                newGroup.Tiles.Add(currentTile);
                currentTile.Group = newGroup;                
            }
            else if(leftTile.IsWater && !bottomTile.IsWater)
            {
                //second case A
                leftTile.Group.Tiles.Add(currentTile);
                currentTile.Group = leftTile.Group;
            }
            else if(!leftTile.IsWater && bottomTile.IsWater)
            {
                //second case B
                bottomTile.Group.Tiles.Add(currentTile);
                currentTile.Group = bottomTile.Group;
            }
            else
            {
                if(leftTile.Group == bottomTile.Group)
                {
                    //third case
                    leftTile.Group.Tiles.Add(currentTile);
                    currentTile.Group = leftTile.Group;
                }
                else
                {
                    //fourth case
                    leftTile.Group.Merge(bottomTile.Group);
                    leftTile.Group.Tiles.Add(currentTile);
                    currentTile.Group = leftTile.Group;
                }
            }
        }
    }

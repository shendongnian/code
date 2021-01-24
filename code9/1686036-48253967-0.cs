    var newPotentialCharacterBounds = 
        GetNewBounds(pbCharacterCat, movementDirection);
    var collidedWalls = pbListeMurs.Where(wall => 
        wall.Bounds.IntersectsWith(newPotentialCharacterBounds));
    if (!collidedWall.Any())
    {
        Debug.Assert(collidedWall.Single); //Sanity check: In these type of 
                                           //games you should be colliding 
                                           //with only one wall
        pbCharacterCat.Bounds = newPotentialCharacterBounds   
    }
    //else do nothing

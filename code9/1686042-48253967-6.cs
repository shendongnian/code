    //event handler for move right fires, and calls:
    TryMove(pbCharacterCat, Direction.Right)
     
    //event handler for move left fires and calls:
    TryMove(pbCharacterCat, Direction.Left)
    //etc.
    
    private static Rectangle GetNewBounds(
        Rectangle current, Direction direction)
    {
         switch (direction)
         {
              case Direction.Right:
              {
                  var newBounds = current;
                  newBounds.Offset(horizontalDelta, 0);
                  return newBounds;
              }
              case Direction.Left:
              {
                  var newBounds = current;
                  newBounds.Offset(-horizontalDelta, 0);
                  return newBounds;
               }
              //etc.   
    }
    //uses System.Linq
    private bool TryMove(Control ctrl, Direction direction)
    {
        var newBounds = 
            GetNewBounds(ctrl.Bounds, direction);
        var collidedWalls = pbListeMurs.Where(wall => 
            wall.Bounds.IntersectsWith(newBounds));
        if (!collidedWall.Any())
        {
            ctrl.Bounds = newBounds;   
            return true;
        }
        //Can't move in that direction
        Debug.Assert(collidedWall.Single); //sanity check
        return false;
    }

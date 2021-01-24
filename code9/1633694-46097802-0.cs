    enum Directions { Right, Down, Left, Up }
    
    Dictionary<Directions, Point> moves = new Dictionary<Directions, Point>
    {
        { Directions.Right, new Point(1, 0) },
        { Directions.Down,  new Point(0, 1) },
        { Directions.Left,  new Point(-1,0) },
        { Directions.Up,    new Point(0,-1) },
    };
    
    int?[,] MakeSpiral(int rows, int columns)
    {
        int?[,] field = new int?[rows, columns];
    
        Point current = new Point(0, 0);
        Directions direction = Directions.Right;
    
        while(true)
        {
            field[current.Y, current.X] = current.X + 1;
            Point next = current + moves[direction];
    
            if(!IsFieldPositionValid(next, current))
            {
                // If we can't make a move, change direction clockwise
                direction = (Directions)((int)(direction + 1) % 4);
            }
    
            next = current + moves[direction];
    
            if(!IsFieldPositionValid(next, current))
            {
                // If we can't make a move after changing the direction
                // it means that we are stuck and we completed the spiral
                return field;
            }
    
            current = next;
        }
    
        // Checks whether we can put a value in a given position
        // taking into consideration whether it is out of bounds of the field 
        // and if it's too close to other values
        bool IsFieldPositionValid(Point position, Point previous)
        {
            if(IsFieldPositionOutOfBounds(position))
                return false;
    
            if(!CheckSurroundings(position, point => !field[point.Y, point.X].HasValue, previous))
                return false;
    
            return true;
        }
        // Checks the positions in 4 directions using the isValid predicate.
        // Doesn't check the point that is given as the exclude parameter:
        // this is used so that we don't count the point we just moved from
        bool CheckSurroundings(Point position, Predicate<Point> isValid, Point? exclude = null)
        {
            foreach(Point move in moves.Values)
            {
                Point newPosition = position + move;
                if(IsFieldPositionOutOfBounds(newPosition))
                    continue;
                if(!isValid(newPosition) && (!exclude.HasValue || exclude.Value != newPosition))
                    return false;
            }
    
            return true;
        }
    
        bool IsFieldPositionOutOfBounds(Point position)
        {
            return position.Y >= field.GetLength(0) || position.X >= field.GetLength(1) || position.Y < 0 || position.X < 0;
        }    
    }

    class MapPathFinder
    {
        public const byte WALL = 1;
        public const byte ROAD = 2;
        public const byte START = 3;
        public const byte FINISH = 5;
        public const byte ALREADY_THERE = 9;
        public bool NextValidMove(MapFile map, int x, int y)
        {
            // Check edges
            if (x < 0 || x > map.width || y < 0 || y > map.height)
                return false;
            byte currentPosition = map.Matrix[x, y];
            // Check walls or already there
            if (currentPosition == WALL || currentPosition == ALREADY_THERE)
                return false;
            // Print
            var status = MapDisplay.DisplayMap(map);
            if (status)
            {
                // Check finish
                if (currentPosition == FINISH)
                {
                    return true; // We've arrived!
                }
                // Road
                //
                // Set ALREADY THERE
                map.Matrix[x, y] = ALREADY_THERE;
                // Left
                if (NextValidMove(map, x - 1, y))
                    return true;
                // Right
                if (NextValidMove(map, x + 1, y))
                    return true;
                // Up
                if (NextValidMove(map, x, y - 1))
                    return true;
                // Down
                if (NextValidMove(map, x, y + 1))
                    return true;
                // Not the correct path.. 
                map.Matrix[x, y] = ROAD;
            }
            return false;
        }
        public bool PathFinder(MapFile map)
        {
            // Looking for start point
            for (int x = 0; x < map.width; x++)
            {
                for (int y = 0; y < map.width; y++)
                {
                    if (map.Matrix[x, y] == START)
                        return NextValidMove(map, x, y);
                }
            }
            return false;
        }
	}

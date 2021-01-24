    public class Tiles
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsChecked { get; set; }
        public bool IsWalkable { get; set; }
        public bool Visited { get; set; }
        private List<Tiles> _neighbours = new List<Tiles>();
        public IEnumerable<Tiles> GetNeighbours()
        {
            return _neighbours;
        }
        public void AddNeighbour(Tiles neighbour)
        {
            if (!_neighbours.Contains(neighbour))
            {
                _neighbours.Add(neighbour);
                neighbour._neighbours.Add(this);
            }
        }
    }
    public static class TileSolver
    {
        // just run this to emulate your example
        public static void RunExample()
        {
            var t1 = GenerateTilePositions();
            var t2 = GenerateTiles(t1);
            var start = t2.First(x => x.X == 0 && x.Y == 8);
            Floodfill(start);
            //Now, we look in every of our tiles.
            foreach (Tiles tile in t2)
            {
                //As soon as it isn't checked, it's an isolated one.
                if (tile.IsWalkable && !tile.IsChecked)
                {
                    //this is the line that makes everything goes infinite.
                    Tiles goal = LookForCheckedWlakable(tile);
                    //we floodfill the remaining one, because we need to check them. Otherwise, the code will restart on a possible next tile.
                    Floodfill(tile);
                    // no need to for the rest, since you claim LookForCheckedWlakable is at fault
                    // and you don't provide code for Pathfind and GetComponentInChildren 
                }
            }
        }
        private static Tiles LookForCheckedWlakable(Tiles t)
        {
            if (t.IsChecked)
                return t;
            else
            {
                foreach (Tiles n in t.GetNeighbours())
                {
                    if (!n.Visited)
                    {
                        n.Visited = true;
                        Tiles result = LookForCheckedWlakable(n);
                        if (result != null)
                            return result;
                    }
                }
            }
            return null;
        }
        private static void Floodfill(Tiles tiles)
        {
            //Create queue to flood fill
            Queue<Tiles> queue = new Queue<Tiles>();
            queue.Enqueue(tiles);
            //We flood fill, aka we look for every components in the neighbours and check them.
            //Any non checkes tiles is isolated.
            while (queue.Count != 0)
            {
                Tiles t = queue.Dequeue();
                t.IsChecked = true;
                foreach (Tiles neighbour in t.GetNeighbours())
                {
                    if (neighbour.IsWalkable && !neighbour.IsChecked)
                        queue.Enqueue(neighbour);
                }
            }
        }
        /// <summary>
        /// generate a hexagon of tile positions for the following indexing pattern:
        /// Suppose a triangle with the points: upper left, upper right, bottom center
        /// The parameter N describes the count of Tiles on the edges of the generated hexagon.
        /// The relation of triangle and hexagon is as follows:
        /// 
        ///      (N - 1, 0) (2N - 2, 0)
        ///   (0, 0) . . x x x . . (3N - 3, 0)
        ///           . x x x x .
        /// (0, N - 1) x x x x x (2N - 2, N - 1)
        ///             x x x x
        ///  (0, 2N - 2) x x x (N - 1, 2N - 2)
        ///               . .
        ///                .
        ///           (0, 3N - 3)
        /// 
        /// The indices start at (x=0, y=0) upper left of the triangle, increasing x while going to the right
        /// and increasing y while going down and half-right.
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        private static List<Tuple<int, int>> GenerateTilePositions()
        {
            int N = 9;
            var result = new List<Tuple<int, int>>();
            for (int x = 0; x < 3 * N - 2; x++)
            {
                for (int y = 0; y < 3 * N - 2; y++)
                {
                    if (N - 2 < x + y &&
                        x + y < 3 * N - 2 &&
                        x < 2 * N - 1 &&
                        y < 2 * N - 1)
                    {
                        result.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            return result;
        }
        private static void SetNotWalkable(Dictionary<Tuple<int, int>, Tiles> tilesDict, int x, int y)
        {
            tilesDict[Tuple.Create(x, y)].IsWalkable = false;
        }
        private static void TryAddNeighbour(Dictionary<Tuple<int, int>, Tiles> tilesDict, Tiles item, int offsetX, int offsetY)
        {
            Tiles neighbour;
            if (tilesDict.TryGetValue(Tuple.Create(item.X + offsetX, item.Y + offsetY), out neighbour))
            {
                item.AddNeighbour(neighbour);
            }
        }
        private static List<Tiles> GenerateTiles(List<Tuple<int, int>> t2)
        {
            var tilesDict = t2.ToDictionary(
                pos => pos,
                pos => new Tiles
                {
                    X = pos.Item1,
                    Y = pos.Item2,
                    IsChecked = false,
                    Visited = false,
                    IsWalkable = true, // some will be changed manually
                });
            // connect neighbours
            foreach (var item in tilesDict.Values)
            {
                TryAddNeighbour(tilesDict, item, -1, 0);
                TryAddNeighbour(tilesDict, item, 1, 0);
                TryAddNeighbour(tilesDict, item, 0, -1);
                TryAddNeighbour(tilesDict, item, 0, 1);
                TryAddNeighbour(tilesDict, item, -1, 1);
                TryAddNeighbour(tilesDict, item, 1, -1);
            }
            // Unchecked Green positions after FloodFill:
            //Tuple.Create(8, 0);
            //Tuple.Create(7, 1);
            //Tuple.Create(7, 2);
            // Special positions (red, black)
            SetNotWalkable(tilesDict, 9, 0);
            SetNotWalkable(tilesDict, 14, 0);
            SetNotWalkable(tilesDict, 15, 0);
            SetNotWalkable(tilesDict, 16, 0);
            SetNotWalkable(tilesDict, 8, 1);
            SetNotWalkable(tilesDict, 11, 1);
            SetNotWalkable(tilesDict, 12, 1);
            SetNotWalkable(tilesDict, 6, 2);
            SetNotWalkable(tilesDict, 8, 2);
            SetNotWalkable(tilesDict, 12, 2);
            SetNotWalkable(tilesDict, 14, 2);
            SetNotWalkable(tilesDict, 6, 3);
            SetNotWalkable(tilesDict, 7, 3);
            SetNotWalkable(tilesDict, 10, 3);
            SetNotWalkable(tilesDict, 13, 3);
            SetNotWalkable(tilesDict, 10, 4);
            SetNotWalkable(tilesDict, 12, 4);
            SetNotWalkable(tilesDict, 13, 4);
            SetNotWalkable(tilesDict, 14, 4);
            SetNotWalkable(tilesDict, 3, 5);
            SetNotWalkable(tilesDict, 6, 5);
            SetNotWalkable(tilesDict, 8, 5);
            SetNotWalkable(tilesDict, 9, 5);
            SetNotWalkable(tilesDict, 12, 5);
            SetNotWalkable(tilesDict, 15, 5);
            SetNotWalkable(tilesDict, 2, 6);
            SetNotWalkable(tilesDict, 3, 6);
            SetNotWalkable(tilesDict, 7, 6);
            SetNotWalkable(tilesDict, 9, 6);
            SetNotWalkable(tilesDict, 16, 6);
            SetNotWalkable(tilesDict, 1, 7);
            SetNotWalkable(tilesDict, 3, 7);
            SetNotWalkable(tilesDict, 7, 7);
            SetNotWalkable(tilesDict, 9, 7);
            SetNotWalkable(tilesDict, 12, 7);
            SetNotWalkable(tilesDict, 16, 7);
            SetNotWalkable(tilesDict, 9, 8);
            SetNotWalkable(tilesDict, 12, 8);
            SetNotWalkable(tilesDict, 13, 8);
            SetNotWalkable(tilesDict, 0, 9);
            SetNotWalkable(tilesDict, 1, 9);
            SetNotWalkable(tilesDict, 6, 9);
            SetNotWalkable(tilesDict, 7, 9);
            SetNotWalkable(tilesDict, 8, 9);
            SetNotWalkable(tilesDict, 10, 9);
            SetNotWalkable(tilesDict, 12, 9);
            SetNotWalkable(tilesDict, 13, 9);
            SetNotWalkable(tilesDict, 3, 10);
            SetNotWalkable(tilesDict, 4, 10);
            SetNotWalkable(tilesDict, 8, 10);
            SetNotWalkable(tilesDict, 10, 10);
            SetNotWalkable(tilesDict, 5, 11);
            SetNotWalkable(tilesDict, 6, 11);
            SetNotWalkable(tilesDict, 9, 11);
            SetNotWalkable(tilesDict, 10, 11);
            SetNotWalkable(tilesDict, 4, 12);
            SetNotWalkable(tilesDict, 6, 12);
            SetNotWalkable(tilesDict, 9, 12);
            SetNotWalkable(tilesDict, 11, 12);
            SetNotWalkable(tilesDict, 6, 13);
            SetNotWalkable(tilesDict, 7, 13);
            SetNotWalkable(tilesDict, 9, 13);
            SetNotWalkable(tilesDict, 11, 13);
            SetNotWalkable(tilesDict, 0, 14);
            SetNotWalkable(tilesDict, 2, 14);
            SetNotWalkable(tilesDict, 3, 14);
            SetNotWalkable(tilesDict, 8, 14);
            SetNotWalkable(tilesDict, 9, 14);
            SetNotWalkable(tilesDict, 0, 15);
            SetNotWalkable(tilesDict, 7, 15);
            SetNotWalkable(tilesDict, 0, 16);
            SetNotWalkable(tilesDict, 2, 16);
            SetNotWalkable(tilesDict, 3, 16);
            SetNotWalkable(tilesDict, 4, 16);
            SetNotWalkable(tilesDict, 5, 16);
            SetNotWalkable(tilesDict, 7, 16);
            return tilesDict.Values.ToList();
        }
    }

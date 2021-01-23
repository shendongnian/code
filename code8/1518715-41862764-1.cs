    public class GridItem<T>
    {
        public int X { get; set; }
        public int Y { get; set; }
    
        public Func<GridItem<T>, Direction, GridItem<T>> onGetNeighbor;
    
        public GridItem<T> GetNeighbor(Direction direction)
        {
            return onGetNeighbor(this, direction);
        }
    }

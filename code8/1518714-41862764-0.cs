    public class Grid<T>
    {
        int width;
        int height;
        public List<GridItem<T>> Cells { get; set; }
    
        public Grid()
        {
            foreach (GridItem<T> cell in Cells)
            {
                cell.onGetNeighbor += OnGetNeighbor;
            }
        }
    
        private GridItem<T> OnGetNeighbor(GridItem<T> self, Direction direction)
        {
            GridItem<T> neighbor = null;
    
            switch (direction)
            {
                case Direction.Top:
                    neighbor = Cells.FirstOrDefault(cell => 
                        cell.X == self.X && cell.Y == self.Y - 1);
                    break;
                case Direction.Bottom:
                    neighbor = Cells.FirstOrDefault(cell =>
                        cell.X == self.X && cell.Y == self.Y + 1);
                    break;
                case Direction.Left:
                    neighbor = Cells.FirstOrDefault(cell =>
                        cell.X == self.X - 1 && cell.Y == self.Y);
                    break;
                case Direction.Right:
                    neighbor = Cells.FirstOrDefault(cell =>
                        cell.X == self.X + 1 && cell.Y == self.Y);
                    break;
                default:
                    break;
            }
    
            return neighbor;
        }
    }

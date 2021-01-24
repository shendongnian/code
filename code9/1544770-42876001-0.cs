    public class GridCell : MonoBehaviour
    {
        public int x;
        public int y;
    }
    public abstract class Grid : MonoBehaviour
    {
        public abstract void Generate(GridCell prefab);
        public abstract GridCell GetAt(int x, int y);
        public abstract List<GridCell> GetNeighboursOf(GridCell cell, List<GridCell> result);
    }
    public class RectGrid : Grid
    {
        public int rows;
        public int columns;
        public RectGrid(int r, int c)
        {
            rows = r;
            columns = c;
        }
        public override GridCell GetAt(int x, int y) { return null; }
        public override List<GridCell> GetNeighboursOf(GridCell cell, List<GridCell> result)
        {
            // You can change this in an hex grid
            result.Add(GetAt(cell.x + 1, cell.y));
            result.Add(GetAt(cell.x - 1, cell.y));
            result.Add(GetAt(cell.x, cell.y + 1));
            result.Add(GetAt(cell.x, cell.y - 1));
            return result;
        }
        // RectGrid knows how to layout its cells
        public override void Generate(GridCell prefab)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    // Instantiate prefab
                }
            }
        }
    }
    public partial class GridExample : MonoBehaviour
    {
        [SerializeField]
        private GridCell gridCell; // prefab
        private void Awake()
        {
            RectGrid grid = GetComponent<RectGrid>();
            grid.Generate(gridCell);
        }
    }

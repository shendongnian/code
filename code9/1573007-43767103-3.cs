    public class GridCellItem
    {
        public GridCellItem()
        {
        }
        public GridCellItem(int r, int c, int? v = null)
        {
            Row = r;
            Col = c;
            Value = v;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public int? Value { get; set; }
    }

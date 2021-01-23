    public class MainWindowViewModel
    {
        private String[] _columnHeaders;
        public String[] ColumnHeaders
        {
            get { return _columnHeaders; }
            set { _columnHeaders = value; }
        }
        private String[] _rowHeaders;
        public String[] RowHeaders
        {
            get { return _rowHeaders; }
            set { _rowHeaders = value; }
        }
        private bool[,] _data2D;
        public bool[,] Data2D
        {
            get { return _data2D; }
            set { _data2D = value; }
        }
        String[] columnHeaders = { "A", "B", "C" };
        String[] rowHeaders = { "1", "2", "3" };
        bool[,] data2D = { { true, true, false }, { true, true, false }, { true, true, false } };
        public MainWindowViewModel()
        {
            ColumnHeaders = columnHeaders;
            RowHeaders = rowHeaders;
            Data2D = data2D;
        }
    }

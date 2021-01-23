    public class ExcelRowProcessor()
    {
        private List<ExcelRow> _rows = new List<ExcelRow>();
        public ExcelRowProcessor(IEnumerable<ExcelRow> rows)
        {
            _rows.AddRange(rows);
        }
        public void Start()
        {
            // Start the thread here.
        }
    }

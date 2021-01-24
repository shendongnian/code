    public class DBDataGridView : DataGridView
    {
        public bool DblBuf {
            get { return DoubleBuffered; }
            set { DoubleBuffered = value; } }
        public DBDataGridView()
        {
            DoubleBuffered = true;
        }
    }

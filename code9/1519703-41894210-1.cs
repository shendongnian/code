    public class DBDataGridView : DataGridView
    {
        public new bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }
    }    
        public DBDataGridView()
        {
            DoubleBuffered = true;
        }
    }

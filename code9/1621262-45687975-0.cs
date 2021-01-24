    namespace SmartBox
    {
        public delegate void CheckCellEventHandler(object sender, DataGridEnableEventArgs e);
    
        public class DataGridEnableEventArgs : EventArgs
        {
            private int _column;
            private int _row;
            private bool _meetsCriteria;
    
            public DataGridEnableEventArgs(int row, int col)//
            {
                _row = row;
                _column = col;
            }
    
            public DataGridEnableEventArgs(int row, int col, bool val)//
            {
                _row = row;
                _column = col;
                _meetsCriteria = val;
            }
    
            public int Column
            {
                get { return _column; }
                set { _column = value; }
            }
    
            public int Row
            {
                get { return _row; }
                set { _row = value; }
            }
    
            public bool MeetsCriteria
            {
                get { return _meetsCriteria; }
                set { _meetsCriteria = value; }
            }
        }
    
    
        class ColumnStyle : DataGridTextBoxColumn
        {
            public event CheckCellEventHandler CheckCellEven;
            public event CheckCellEventHandler CheckRowContains;
    
            private int _col;
    
            public ColumnStyle(int column)
            {
                _col = column;
            }
    
            protected override void Paint(Graphics g, Rectangle Bounds, CurrencyManager Source, int RowNum, Brush BackBrush, Brush ForeBrush, bool AlignToRight)
            {
                bool enabled = true;
    
                if (CheckCellEven != null)
                {
                    DataGridEnableEventArgs e = new DataGridEnableEventArgs(RowNum,_col, enabled);//, _col
                    CheckCellEven(this, e);
                    if (e.MeetsCriteria)
                        BackBrush = new SolidBrush(Color.PaleGreen);
    
                }
    
                if (CheckRowContains != null)
                {
                    DataGridEnableEventArgs e = new DataGridEnableEventArgs(RowNum, _col, enabled);
                    CheckRowContains(this, e);
                    if (e.MeetsCriteria)
                    {
                        BackBrush = new SolidBrush(Color.Yellow);
                    }
                }
    
                base.Paint(g, Bounds, Source, RowNum, BackBrush, ForeBrush, AlignToRight);
            }
        }

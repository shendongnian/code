    public partial class Form1 : Form
    {
        private int _checkedCount;
    
        public Form1()
        {
            InitializeComponent();
    
            dataGridView1.CellBeginEdit += ( sender , e ) =>
            {
                var dataGridViewCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if ( dataGridViewCell.ValueType == typeof( bool ) )
                    e.Cancel = _checkedCount == 3;
            };
    
            dataGridView1.CellValueChanged += ( sender , e ) =>
            {
                var dataGridViewCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if ( dataGridViewCell.ValueType == typeof( bool ) )
                    _checkedCount += 1;
            };
        }
    }

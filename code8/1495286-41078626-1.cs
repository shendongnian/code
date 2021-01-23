    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            var checkBoxColumn = (DataGridViewCheckBoxColumn)this.dataGridView1.Columns[0];
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;
    
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }
    
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell cell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
    
            if (cell != null)
            {
                if (cell.Value == cell.TrueValue)
                {
                    MessageBox.Show("Cell checked.");
                }
                else
                {
                    MessageBox.Show("Cell unchecked.");
                }
            }
        }
    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
    
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Raise CellValueChanged
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }

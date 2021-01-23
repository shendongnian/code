    public partial class DataBox : UserControl
    {
        public DataBox()
        {
            InitializeComponent();
        }
        public DataBox(DataGridView dgv, int row)
        {
            InitializeComponent();
            DGV = dgv;
            loadRow(row);
        }
        public int rowID { get; set; }
        public DataGridView DGV { get; set; }
        public void loadRow(int row)
        {
            if (DGV == null) return;
            if (DGV.ColumnCount < 3) return;
            if (DGV.RowCount < row + 1) return;
            label1.Text = DGV[0, row].Value.ToString();
            label2.Text = DGV[1, row].Value.ToString();
            label3.Text = DGV[2, row].Value.ToString();
            rowID = row;
        }
    }

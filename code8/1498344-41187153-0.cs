    public partial class Form1 : Form
    {
        private DataSet _dataSet = new DataSet();
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataSet(_dataSet);
        }
    
        private void SelectByID(int searchId)
        {
            ISelectionManager selectionManager = this.ultraGrid1;
    
            foreach (UltraGridRow row in this.ultraGrid1.Rows)
            {
                if (Convert.ToInt32(row.Cells["ID"].Value) == searchId)
                {
                    if (ultraGrid1.ActiveRowScrollRegion.IsActiveScrollRegion)
                    {
                        ultraGrid1.ActiveRowScrollRegion.ScrollRowIntoView(row);
    
                        // Activating and selecting are two different things.
                        // Activating the row draws dotted border around it.
                        // Selecting the row highlights it with blue color by default.
                        row.Activated = true;
                        row.Selected = true;
                        break;
                    }
                }
            }
        }
    
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            var dataSourceRows = _dataSet.Tables[0].Rows;
            var dataRow = dataSourceRows.Add(new object[] { dataSourceRows.Count });
    
            SelectByID(dataSourceRows.Count - 1);
        }
    
        private void InitializeDataSet(DataSet dataSet)
        {
            var dataTable = dataSet.Tables.Add();
    
            dataTable.Columns.Add("ID", typeof(int));
    
            for (int index = 0; index <= 100; index++)
            {
                dataTable.Rows.Add(new object[] { index });
            }
    
            this.ultraGrid1.DataSource = dataTable;
        }
    }

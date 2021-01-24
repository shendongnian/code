    public partial class Customers : Form
    {
        private Cache memoryCache;
        public Customers()
        {
            InitializeComponent();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            dgv_data.VirtualMode = true;
            Load_Data();
        }
        private void Load_Data()
        {
            try
            {
                DataRetriever retriever =
                    new DataRetriever(Global.RetrieverCNS, "*Database Table Name*",null,true);
                memoryCache = new Cache(retriever, 100);
                foreach (DataColumn column in retriever.Columns)
                {
                    dgv_data.Columns.Add(
                        column.ColumnName, column.ColumnName);
                }
                this.dgv_data.RowCount = retriever.RowCount;
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection could not be established. " +
                    "Verify that the connection string is valid.");
                Application.Exit();
            }
        }
        void dgv_data_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }
    }

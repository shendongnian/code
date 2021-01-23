    public partial class Form1 : Form
    {
        private bool _IsEnterKeyDown = false;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            ultraGrid1.KeyDown += new KeyEventHandler(ultraGrid1_KeyDown);
            ultraGrid1.BeforeRowUpdate += new CancelableRowEventHandler(ultraGrid1_BeforeRowUpdate);
            ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(ultraGrid1_InitializeLayout);
            ultraGrid1.DataSource = GetDataTable();
        }
    
        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                _IsEnterKeyDown = true;
            }
        }
    
        private void ultraGrid1_BeforeRowUpdate(object sender, CancelableRowEventArgs e)
        {
            if (e.Row.IsAddRow && _IsEnterKeyDown)
            {
                _IsEnterKeyDown = false;
                ultraButton1.PerformClick();
            }
        }
    
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button click event raised!");
        }
    
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
        }
    
        private DataTable GetDataTable(int rows = 10)
        {
            DataTable table = new DataTable("Table1");
    
            table.Columns.Add("Boolean column", typeof(bool));
            table.Columns.Add("Integer column", typeof(int));
            table.Columns.Add("DateTime column", typeof(DateTime));
            table.Columns.Add("String column", typeof(string));
    
            for (int i = 0; i < rows; i++)
            {
                DataRow row = table.NewRow();
                row["Boolean column"] = i % 2 == 0 ? true : false;
                row["Integer column"] = i;
                row["String column"] = "text";
                row["DateTime column"] = DateTime.Today.AddDays(i);
                table.Rows.Add(row);
            }
    
            return table;
        }
    }

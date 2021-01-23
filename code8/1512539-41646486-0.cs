    public Form1()
    {
       InitializeComponent();
       DataTable dt = new DataTable();
       dt.ReadXml(Application.StartupPath + @"\test.xml");
       csv_datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
       csv_datagridview.DataSource = dt;
    }
    private void button1_Click(object sender, EventArgs e)
    {
       List<object> destList = new List<object>();
       foreach (DataGridViewRow row in csv_datagridview.SelectedRows)
          destList.Add(row.DataBoundItem);
       optimaldataGridView.DataSource = destList;
    }

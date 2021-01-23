    public MainForm() {
        InitializeComponent();
		    
        DataTable dt = new DataTable();
        dt.Columns.Add("companyName");
		    
        for (int i = 0; i < 10; i++)
            dt.Rows.Add("item" + i.ToString());
		    
            listBox1.DataSource = dt;
            listBox1.ValueMember = "companyName";
        }
		
    private void filterButton_Click(object sender, EventArgs e) {
        DataRowView selectedRow = (DataRowView) listBox1.SelectedItem;
        string text = (string) selectedRow[0];
        MessageBox.Show(text, "", MessageBoxButtons.OK);
    }

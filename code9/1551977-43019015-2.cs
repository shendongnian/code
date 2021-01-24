    private void button4_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void BindGrid()
    {
        string path = "C:\\Users\\Excel\\Desktop\\Coding\\DOT.NET\\Samples C#\\Export DataGridView to SQL Server Table\\Import_List.xls";
        string jet = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
        OleDbConnection conn = new OleDbConnection(jet);
        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dataGridView1.DataSource = dt;
        BulkUpload();
    }

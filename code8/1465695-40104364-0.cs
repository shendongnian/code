    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable dataTable = GetDataTable(10);
        gridControl1.DataSource = dataTable;
    }
    
    private DataTable GetDataTable(int rows = 1)
    {
        DataTable table = new DataTable("Table1");
    
        table.Columns.Add("checklist", typeof(int));
        table.Columns.Add("cek22", typeof(bool));
    
        for (int i = 0; i < rows; i++)
        {
            DataRow row = table.NewRow();
            row["checklist"] = i % 2 == 0 ? 0 : 1;
            row["cek22"] = ((int)row["checklist"]) == 0 ? false : true;
                
            table.Rows.Add(row);
        }
    
        return table;
    }

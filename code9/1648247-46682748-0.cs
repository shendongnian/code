    private void InitDataGridView()
    {
        DataTable table = new DataTable();        
        table.Columns.Add("1");
        table.Columns.Add("2");
        table.Columns.Add("3");
        table.Columns.Add("4");
        table.Columns.Add("5");
        table.Rows.Add("1", 2, 3, "4", 5);
        table.Rows.Add("11", 21, 31, "41", 51);
        table.Rows.Add("11", 12, 13, "14", 15);
        table.Rows.Add("21", 22, 23, "24", 25);
        table.Rows.Add("13", 32, 33, "34", 35);
    }
    dataGridView1.DataSource = table;

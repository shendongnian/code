    private void Form1_Load(object sender, EventArgs e)
    {
        var originalTable = new DataTable();
        originalTable.Columns.Add("C1");
        originalTable.Columns.Add("C2");
        //Original data
        originalTable.Rows.Add("A", "B");
        originalTable.Rows.Add("X", "Y");
        originalTable.Rows.Add("A", "B");
        originalTable.Rows.Add("X", "Y");
        //An ArrayList containing duplicate DataRow objects
        var duplicates = new System.Collections.ArrayList();
        duplicates.Add(originalTable.Rows[2]);
        duplicates.Add(originalTable.Rows[3]);
        //Create a Table having the same schema of the original table
        var duplicatesTable = originalTable.Clone();
        //Add copy of duplicates to the duplicate table
        foreach (DataRow item in duplicates)
        {
            duplicatesTable.Rows.Add(item.ItemArray);
        }
        this.dataGridView1.DataSource = duplicates;
    }

    private void PopulateThirdCombo()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product ID");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Product Price");
            dt.Columns.Add();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Product Price";
            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridView1.Rows.Add(row);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Action";
            btn.Text = "Delete";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;     
        }
        catch (Exception)
        {
                
        }
    }
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            //this will be index of your delete button
            if (e.ColumnIndex == 3)
            {
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
        catch (Exception)
        {
                
        }
    }

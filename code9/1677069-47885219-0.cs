     private void button1_Click(object sender, EventArgs e)
        {
            DataTable cDataTable = new DataTable();
            DataColumn a = new DataColumn("Select", typeof(bool));
            cDataTable.Columns.Add(a);
            for (int i = 0; i < 100; i++)
            {
                cDataTable.Rows.Add(true);
            }
            cDataTable.Rows[5][a] = false;
            dataGridView1.DataSource = cDataTable;
        }

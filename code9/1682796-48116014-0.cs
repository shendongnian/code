    int checkedRowCount = 0;
    Parallel.ForEach(
        dataGridView1.Rows.Cast<DataGridViewRow>()
        , row =>
        {
            DataGridViewCell cell = row.Cells[6];
            if (!(cell.Value is DBNull))
            {
                if (Convert.ToBoolean(cell.Value))
                {
                    checkedRowCount++;
                    for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                    {
                        // Works on The other column value    
                        // Add the value to excel here   
                    }
                    
                    // Add to the ListBox only once per Row, Instead of Once per Column per Row
                    listBox1.BeginInvoke((Action)(() =>
                    {
                        listBox1.Items.Add(checkedRowCount);
                    }));
                }
            }
        });

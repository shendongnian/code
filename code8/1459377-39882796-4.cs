        foreach (DataRow item in dt.Rows)
        {
       
        int n = dataGridView1.Rows.Add();
     DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(dataGridView1.Rows[n].Cells[1]);
                ContactCombo.Value = item[0].ToString();
        
        dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
        }

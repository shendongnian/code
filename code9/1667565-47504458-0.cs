    string targetSearch = textBox2.Text;
    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    foreach(DataGridViewRow row in dataGridView1.Rows)
    {
        if (row.Cells[0].Value == null) continue; //add this 
        if (row.Cells[0].Value.ToString().Equals(targetSearch))
        {
            row.Selected = true;
            break;
        }
    }

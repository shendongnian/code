    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {            
        List<string> someList = new List<string>();
 
        foreach (DataGridViewRow row in this.dataGridView1.Rows)
        {
            var cell = row.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(cell.Value) == true)
            {
                if (cell.State != DataGridViewElementStates.Selected)
                {
                    someList.Add(row.Cells[1].Value.ToString();
                }
            }
            else if (cell.State == DataGridViewElementStates.Selected)
            {
                someList.Add(row.Cells[1].Value.ToString();
            }
        }   
    }

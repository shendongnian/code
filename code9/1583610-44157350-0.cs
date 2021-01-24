    public void checkIfRowIsEmpty()
    {
        foreach (DataGridViewRow rw in this.dataGridView1.Rows)
        {
            for (int i = 0; i < rw.Cells.Count; i++)
            {
               if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString())
               {
               dataGridView1.AllowUserToAddRows = false;
               break;
               }
               else
               {
               dataGridView1.AllowUserToAddRows = true;
               }
            } 
        }
    }

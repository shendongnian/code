    private void RemoveInvisibleSelection()
    {
         if (dataGridView1.SelectedRows.Count == dataGridView1.Rows.Count)
         {
             for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                 if (!dataGridView1.SelectedRows[i].Visible)
                     dataGridView1.SelectedRows[i--].Selected = false; // decreased the index value since SelectedRows property loses an object
         }
    }

    private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
        DataGridView gv = sender as DataGridView;
        if (gv != null && gv.SelectedRows.Count > 0)
            {
            DataGridViewRow row = gv.SelectedRows[0];
            if (row != null)
                {
                if(Convert.ToInt32(row.Cells["IdColumn"].Value)==user.Id)
                  {
    
                          //do whatever we want
   
                   }
               
                }
            }
        }

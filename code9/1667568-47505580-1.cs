    private void btnSearch_Click(object sender, EventArgs e)
    {
         string targetSearch = txtSearch.Text.Trim();
         dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(targetSearch))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
                catch (NullReferenceException ex) {   }
    }

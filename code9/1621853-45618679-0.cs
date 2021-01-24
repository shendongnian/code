    bool bDisplayed = false;
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (Convert.ToDateTime(row.Cells[3].Value) >= DateTime.Parse("0:05:00")
            && Convert.ToDateTime(row.Cells[3].Value) <= DateTime.Parse("0:19:59") 
            && row.Cells[1].Value.ToString().Trim() == "4 - Needs to be solved")
        {
            if(!bDisplayed)
            {
                MessageBox.Show("You have 1 task to be solved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bDisplayed = true;
            }
        }
    }

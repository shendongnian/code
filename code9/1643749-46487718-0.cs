    tabControl1.SelectedTab = 0; //select first tab page    
    foreach (DataGridViewRow r in dgvTickets.Rows)
    {
            if (r.Cells[8].Value.ToString() == "Completed")
            {
                r.DefaultCellStyle.BackColor = Color.LightGreen;
            }
    
            else if (r.Cells[8].Value.ToString() == "Cancelled")
            {
                r.DefaultCellStyle.BackColor = Color.LightPink;
            }
        }
    
    tabControl1.SelectedTab = 1   //select second tab 
    foreach (DataGridViewRow rFX in dgvFXTickets.Rows)
        {
            if (rFX.Cells[12].Value.ToString() == "Completed")
            {
                rFX.DefaultCellStyle.BackColor = Color.LightGreen;
            }
    
            else if (rFX.Cells[12].Value.ToString() == "Cancelled")
            {
                rFX.DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        // to set oem no, fic_no and seiken_no to textbox named particular1Txt.
        dataGridView1.Refresh();
        try
        {
            if (RB1.Checked == true)
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                Particular1Txt.Text = dataGridView1.Rows[i].Cells["FIC_No"].Value.ToString()+" "+ dataGridView1.Rows[i].Cells["OEM_No"].Value.ToString()+" "+dataGridView1.Rows[i].Cells["Seiken_NO"].Value.ToString();
            }
            else if (RB2.Checked == true)
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
    			Particular1Txt.Text = dataGridView1.Rows[i].Cells["FIC_No"].Value.ToString()+" "+ dataGridView1.Rows[i].Cells["OEM_No"].Value.ToString()+" "+dataGridView1.Rows[i].Cells["Seiken_NO"].Value.ToString();
            }
    	}
    }

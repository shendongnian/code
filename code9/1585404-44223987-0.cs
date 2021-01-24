    private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        switch (dgvBills.Columns[e.ColumnIndex].Name)
        {
            case "img": // The name of your image column 
                if (dgvBills.Rows[e.RowIndex].Cells[11].Value.ToString() == "open")
                    e.Value = pbox.Image; // image stored in a PictureBox
                else
                    e.Value = pbox.InitialImage; // image stored in a PictureBox
                break;
        }
    }

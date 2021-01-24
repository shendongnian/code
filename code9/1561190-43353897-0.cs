    private void DGV1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        int QTY = Int32.Parse(DGV1.Rows[e.RowIndex].Cells[4].Value.ToString());
            if(QTY >=21 && QTY <= 50)
            { 
                DGV1.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.Yellow;
                DGV1.Rows[e.RowIndex].Cells[4].Style.Font = new Font("Arial", 11, FontStyle.Bold);
            }
            else if (QTY >= 0 && QTY <= 20)
            { 
              DGV1.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.Red;
              DGV1.Rows[e.RowIndex].Cells[4].Style.Font = new Font("Arial", 11, FontStyle.Bold);
            }
            else
            { 
              DGV1.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.Green;
              DGV1.Rows[e.RowIndex].Cells[4].Style.Font = new Font("Arial", 11, FontStyle.Bold);
            }
    }

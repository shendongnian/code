     private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(1, 1);
            G1_CellClick(sender, ee);
        }
    private void G1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           decimal quantity = 0, avai = 0, newavai = 0;
            decimal totalstock = 0, newtotalstock = 0;
            if (decimal.TryParse(G1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity) && decimal.TryParse(G1.Rows[e.RowIndex].Cells["AvailableStock"].Value.ToString(), out avai))
            {
                newavai = avai + quantity;
                G1.Rows[e.RowIndex].Cells["AvailableStock"].Value = newavai.ToString();
            }
            if (decimal.TryParse(G1.Rows[e.RowIndex].Cells["TotalStock"].Value.ToString(), out totalstock) && decimal.TryParse(G1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity))
            {
                newtotalstock = totalstock + quantity;
                G1.Rows[e.RowIndex].Cells["TotalStock"].Value = newtotalstock.ToString();
            }
        }

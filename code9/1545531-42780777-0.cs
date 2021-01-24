    private void G2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            decimal quantity, cost;
            if (decimal .TryParse(G2.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity) && decimal .TryParse(G2.Rows[e.RowIndex].Cells["Cost2"].Value.ToString(), out cost))
            {
                decimal total= quantity * cost;
                G2.Rows[e.RowIndex].Cells["Total"].Value = total.ToString();
            }
            int quan, mini;
            quan = Convert.ToInt32(G2.Rows[e.RowIndex].Cells["Quantity"].Value);
            mini = Convert.ToInt32(G2.Rows[e.RowIndex].Cells["MinimumOrder2"].Value);
            if (quan < mini)
            {
                MessageBox.Show("QUANTITY must be GREATER or EQUAL to MINIMUM ORDER", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                G2.Rows[e.RowIndex].Cells["Quantity"].Value = "";
                G2.Rows[e.RowIndex].Cells["Total"].Value = "";
                return;
            }
            else
            {
                //Sum the Total Column to TOTAL VALUES text box
                decimal TotalValue = 0;
                for (int i = 0; i < G2.Rows.Count; i++)
                {
                    if (G2.Rows[i].Cells["Total"].Value == DBNull.Value)
                    {
                        return;
                    }
                    else
                    {
                        TotalValue += Convert.ToDecimal(G2.Rows[i].Cells["Total"].Value);
                    }
                }
                totalvalue.Text = TotalValue.ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Please Enter Only Number");
            return;
        }
    }

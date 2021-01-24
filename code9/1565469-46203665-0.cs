    string valueTRP;
    string valueQTY;
    private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex > -1)
        {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[Rate.Index].Value.ToString() != "")
                {
                    valueTRP = row.Cells[Rate.Index].Value.ToString();
                }
                else
                {
                    valueTRP = "0";
                }
                if (row.Cells[Qty.Index].Value.ToString() != "")
                {
                    valueQTY = row.Cells[Qty.Index].Value.ToString();
                }
               if (Decimal.TryParse(valueTRP, out result) && Decimal.TryParse(valueQTY, out result))
                {
                    decimal vTRP = Convert.ToDecimal(valueTRP);
                    decimal vQTY = Convert.ToDecimal(valueQTY);
                    decimal z = vTRP * vQTY;
                    string x = z.ToString("F");
                    row.Cells[Amount.Index].Value = x;
                }
        }
    }

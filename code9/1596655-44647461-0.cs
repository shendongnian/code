     private void btn_total_Click(object sender, EventArgs e)
     {
        //int[] columnData = (from DataGridViewRow row in dataGridView3.Rows    where row.Cells[2].FormattedValue.ToString() != string.Empty select Convert.ToInt32(row.Cells[2].FormattedValue)).ToArray();
        //lbl_sum.Text = columnData.Sum().ToString();
        int sum = 0;
        for (int i = 0; i < dataGridView3.Rows.Count; ++i)
        {
           if(Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value != null && Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value != DbNull.Value)
            sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
        }
        int bal = 0;
        for (int i = 0; i < dataGridView3.Rows.Count; ++i)
        {
           if(Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value != null && Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value != DbNull.Value)
            bal = Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value) - sum;
        }
        if (bal <0)
        {
            label_bal_pay.Text = bal.ToString();
        }
        else
        {
            lbl_bal.Text = bal.ToString();
        }
        label_bal_pay.Text = bal.ToString();
        lbl_bal.Text = bal.ToString();
        lbl_sum.Text = sum.ToString();
     }

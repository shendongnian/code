    private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (!checkBox1.Checked)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();
                        item.Visible = dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor == System.Drawing.Color.Yellow;
                        currencyManager1.ResumeBinding();
    
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();
                        item.Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                }
            }

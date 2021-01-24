    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in addSellItemsDgv.SelectedRows)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[addSellItemsDgv.DataSource];
            currencyManager1.SuspendBinding();
            addSellItemsDgv.CurrentCell = null;
            row.Visible = false;
        }
        addSellItemsDgv.Refresh();
        double count = 0;
        if (addSellItemsDgv.Rows.GetRowCount(DataGridViewElementStates.Visible) > 0)
        {
            foreach (DataGridViewRow row in addSellItemsDgv.Rows)
            {
                if (row.Visible == true)
                {
                    count += Convert.ToDouble(row.Cells[6].FormattedValue.ToString());
                }
            }
            addSellTtlCostLbl.Text = count.ToString();
        }
        else
        {
            addSellTtlCostLbl.Text = "0";
        }
    }

    private void qoutaGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int min = qoutaGrid.Rows.Cast<DataGridViewRow>().Min(r => Convert.ToInt32(r.Cells["MyProperty"].Value));
            int max = qoutaGrid.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["MyProperty"].Value));
            for (int i = 0; i < qoutaGrid.Rows.Count; i++)
            {
                int value = Convert.ToInt32(qoutaGrid.Rows[i].Cells["MyProperty"].Value);
                if (value == min)
                {
                    qoutaGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (value == max)
                {
                    qoutaGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

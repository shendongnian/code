    private void cbx_all_CheckedChanged(object sender, EventArgs e)
    {
        if (cbx_all.Tag == null) for (int i = 0; i < dataGridView.RowCount; i++)
        {
            dataGridView.Tag = "busy";
            dataGridView[yourCheckBoxcolumnIndex, i].Value = cbx_all.Checked;
            dataGridView.Tag = null;
        }
    }

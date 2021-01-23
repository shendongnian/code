    private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == yourCheckBoxcolumnIndex &&  dataGridView.Tag == null)
        {
           cbx_all.Tag = "busy";
           cbx_all.Checked = testChecks(e.ColumnIndex);
           cbx_all.Tag = null;
        }
    }

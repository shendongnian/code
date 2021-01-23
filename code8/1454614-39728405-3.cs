    private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        DataGridViewCell cell = dgv.CurrentCell;
        if (cell is DataGridViewComboBoxCell)
        {
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgv.EndEdit();
        }
    }

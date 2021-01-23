    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (CurrentCell is DataGridViewComboBoxCell)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView1.EndEdit();
        }
    }

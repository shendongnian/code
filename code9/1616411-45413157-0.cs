    DataGridViewComboBoxEditingControl cbec = null;
    private void dataGridView1_EditingControlShowing(object sender, 
                               DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is DataGridViewComboBoxEditingControl)
        {
            cbec = e.Control as DataGridViewComboBoxEditingControl;
            cbec.SelectedIndexChanged -=Cbec_SelectedIndexChanged;
            cbec.SelectedIndexChanged +=Cbec_SelectedIndexChanged;
        }
    }
    private void Cbec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbec != null) Console.WriteLine(cbec.SelectedItem.ToString());
    }

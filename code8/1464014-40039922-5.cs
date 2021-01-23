    DataGridViewComboBoxEditingControl comboBox = (DataGridViewComboBoxEditingControl)sender;
    DataGridView dgv = comboBox.EditingControlDataGridView; 
    if (comboBox.Items != null && dgv != null)
    {
        DataGridViewComboBoxColumn dcbc =
            (DataGridViewComboBoxColumn) dgv.Columns[dgv .CurrentCell.ColumnIndex];
            
        List<String> elementname = Elements.ToList();
        foreach (string s in elementname)
        {
            if (!comboBox.Items.Contains(s))
            {
              comboBox.Items.Add(s);
              dcbc.Items.Add(s);
            }
        }
    }

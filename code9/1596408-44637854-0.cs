    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {
        advancedDataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        advancedDataGridView2.ClearSelection();
        foreach (DataGridViewRow item in advancedDataGridView2.Rows)
        {
            if (item.Cells[1].Value.ToString().Equals(textBox1.Text))
            {
                advancedDataGridView2.CurrentCell = item.Cells[1];
                advancedDataGridView2.BeginEdit(true);
            }
        }   
    }

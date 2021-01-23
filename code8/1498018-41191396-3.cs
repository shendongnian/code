    this.dataGridView1.EditingControlShowing += this.DataGridView1_EditingControlShowing;
    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is TextBox)
        {
            TextBox tb = e.Control as TextBox;
            tb.TextChanged -= Tb_TextChanged;
            tb.TextChanged += Tb_TextChanged;
        }
    }

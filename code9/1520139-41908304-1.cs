    private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        var margs = new MouseEventArgs(MouseButtons, 1, MousePosition.X, MousePosition.Y, 0);
        var args = new DataGridViewCellMouseEventArgs(e.Column.Index, 0, MousePosition.X, MousePosition.Y, margs);
        dataGridView1_ColumnHeaderMouseClick(sender, args);
    }

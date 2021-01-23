    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Right))
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            DataGridViewCell cell = dataGridView1[hit.ColumnIndex, hit.RowIndex];
            // call some event..
            yourInfoAction(cell.Value);
        }
    }

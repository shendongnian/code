    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            finalValue = ((DataGridView)sender).Rows[hit.RowIndex].Cells[0].Value.ToString();
        }

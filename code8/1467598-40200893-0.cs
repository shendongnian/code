    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Unsaved())
      {
        DialogResult r = MessageBox.Show("Proceed without saving?", "Unsaved data", MessageBoxButtons.YesNo);
        if (r != DialogResult.Yes)
         return;
      }
      Data.Clear();
      dataGridView1.Rows.Clear();
      //dataGridView1.Refresh();
      //dataGridView1.Focus();
      dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
      dataGridView1.Rows[0].Cells[0].Selected = true;
      dataGridView1.BeginEdit(true);
    }

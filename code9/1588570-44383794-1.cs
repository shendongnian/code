     private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int current = dataGridView1.CurrentRow.Index;
                if (e.KeyData == Keys.Down)
                {
                    e.Handled = true;
                    dataGridView1.SuspendLayout();
                    for (int i = current; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.CurrentRow.Cells["BoxNo"].Value.ToString() != dataGridView1.Rows[i].Cells["BoxNo"].Value.ToString())
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells["BoxNo"];
                            break;
                        }
                    }
                    dataGridView1.ResumeLayout();
                }
                else if (e.KeyData == Keys.Up)
                {
                    e.Handled = true;
                    dataGridView1.SuspendLayout();
                    for (int i = current; i >= 0; i--)
                    {
                        if (dataGridView1.CurrentRow.Cells["BoxNo"].Value.ToString() != dataGridView1.Rows[i].Cells["BoxNo"].Value.ToString())
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells["BoxNo"];
                            break;
                        }
                    }
                    dataGridView1.ResumeLayout();
                }
            }
        }

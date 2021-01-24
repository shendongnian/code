        List<int> selectedRowsIndexes = new List<int>();
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedRowsIndexes.Clear();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
               selectedRowsIndexes.Add(row.Index);
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip smenu = new System.Windows.Forms.ContextMenuStrip();
                var htest = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[htest.RowIndex].Selected = true;
                smenu.Items.Add("Clear Record").Name = "Clear Record";
                smenu.Items.Add("Pay Amount").Name = "Pay Amount";
                smenu.Items.Add("Break Apart").Name = "Break Apart";
                smenu.Items.Add("View Details").Name = "View Details";
                smenu.Items.Add("Choose Selected").Name = "Choose Selected"; // Choose Rows Option
                smenu.Items.Add("Reset").Name = "Reset";
                int CurrentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                smenu.Show(dataGridView1, new Point(e.X, e.Y));
                foreach (int rowIndex in selectedRowsIndexes)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                       dataGridView1.Rows[i].Selected = (i == rowIndex);
                    }
                }
            }
        }

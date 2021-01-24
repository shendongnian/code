			dataGridView1.ClearSelection();
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				for (int c = 0; c < dataGridView1.Columns.Count; c++)
				{
					if (dataGridView1.Rows[i].Cells[c].Value.ToString() == radtextBox1.Text)
					{
						dataGridView1.Rows[i].Selected = true;
						
					}
				}
			}

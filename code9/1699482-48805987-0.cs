    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			DataGridView view = sender as DataGridView; 
			if (view.AreAllCellsSelected(true))
			{
				foreach (DataGridViewRow row in view.Rows)
				{
					//deselect all invisible rows
					if (!row.Visible)
						row.Selected = false;
				}
			}
		}
   

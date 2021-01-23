				private void selectedCellsButton_Click(object sender, System.EventArgs e)
				{
					Int32 selectedCellCount =
						dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
					if (selectedCellCount > 0)
					{
						if (dataGridView1.AreAllCellsSelected(true))
						{
							MessageBox.Show("All cells are selected", "Selected Cells");
						}
						else
						{
							System.Text.StringBuilder sb =
								new System.Text.StringBuilder();
							for (int i = 0;
								i < selectedCellCount; i++)
							{
								sb.Append(dataGridView1.SelectedCells[i].Value.ToString()) ;
							 
						  MessageBox.Show(sb.ToString(), "Selected Cells");
						 
						}
					}
				}

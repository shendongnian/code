    private void dGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dGV.Rows[e.RowIndex];
              if (item_type.ToString() == "item1")
                {
                    try
                    {
                         DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells[3]);
                         cell.DataSource = new string[] { "Item1","Item2"};
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }

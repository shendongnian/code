    private void GvOpStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0) 
                    for (int row = 0; row < GvOpStock.Rows.Count - 1; row++)
                    {
                        if (GvOpStock.Rows[row].Cells[1].Value != null &&
                            row != e.RowIndex &&
                            GvOpStock.Rows[row].Cells[1].Value.Equals(GvOpStock.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        {
                            MessageBox.Show("Duplicate");
                            return;
                        }
                        else
                        {
                            //Add To datagridview
                        }
                    }
            }
            catch (Exception ex)
            {
            }
        }

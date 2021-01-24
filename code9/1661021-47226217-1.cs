    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                DataGridView grid = (DataGridView)sender;
                DataGridViewRow row = grid.Rows[e.RowIndex];
                DataGridViewColumn col = grid.Columns[e.ColumnIndex];
                if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
                {
                    string[] props = col.DataPropertyName.Split('.');
                    PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                    if(propInfo != null)
                    {
                        object val = propInfo.GetValue(row.DataBoundItem, null);
                        for (int i = 1; i < props.Length; i++)
                        {
                            propInfo = val.GetType().GetProperty(props[i]);
                            val = propInfo.GetValue(val, null);
                        }
                        e.Value = val;
                    }
                    else
                    {
                        DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        DataGridViewComboBoxCell chkCell = cell as DataGridViewComboBoxCell;
                        chkCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        cell.ReadOnly = true;
                    }
                }
            }

        private void datagridSB_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridSB.Columns[e.ColumnIndex].Name == "withCashSB")
            {
                DataGridViewCheckBoxCell buttonCell = (DataGridViewCheckBoxCell)datagridSB.Rows[e.RowIndex].Cells["withProCSB"];
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)datagridSB.Rows[e.RowIndex].Cells["withCashSB"];
                buttonCell.Value = !(Boolean)checkCell.Value;
                datagridSB.Invalidate();
            }
            else if (datagridSB.Columns[e.ColumnIndex].Name == "withProCSB")
            {
                DataGridViewCheckBoxCell buttonCell = (DataGridViewCheckBoxCell)datagridSB.Rows[e.RowIndex].Cells["withCashSB"];
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)datagridSB.Rows[e.RowIndex].Cells["withProCSB"];
                buttonCell.Value = !(Boolean)checkCell.Value;
                datagridSB.Invalidate();
            }
        }
        private void datagridSB_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagridSB.IsCurrentCellDirty)
            {
                datagridSB.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

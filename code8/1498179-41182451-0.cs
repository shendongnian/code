    private void datagridview1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                if (cmbCombo != null)
                {
                    DataRowView oDataRowView = cmbCombo.SelectedItem as DataRowView;
                    string sValue = string.Empty;
    
                    if (oDataRowView != null)
                    {
                        sValue = oDataRowView.Row["ValueMemberID"] as string;
                    }
                    datagridview1[e.ColumnIndex, e.RowIndex].Tag = sValue;
                }
    
            }

    object PreValue = null;
    bool StopAction = false;
    private void RationFormulationdgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        PreValue = RationFormulationdgv[e.ColumnIndex, e.RowIndex].Value;
        try
        {
            if (Convert.ToDouble(PreValue) >= 0)
            {
               StopAction = false;
            }
        }
        catch (Exception)
        {
            MessageBox.Show("ErrorInSetingStopAction");
        }
    }

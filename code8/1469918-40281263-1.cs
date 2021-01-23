    private void RationFormulationdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (FirstShown == true)
        {
            return;
        }
        if (PreValue != null && StopAction==false)
        {
            string Value = RationFormulationdgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (Value == string.Empty)
            {
                MessageBox.Show("Please Insert a Number!");
                StopAction = true;
                RationFormulationdgv.Rows[e.RowIndex].
                Cells[e.ColumnIndex].Value = PreValue;   
            }
            else
            {
                try
                {
                    Double CellValue = Double.Parse(Value);
                    if (CellValue < 0)
                    {
                        MessageBox.Show("Please use ONLY positive Number");
                        StopAction = true;
                        RationFormulationdgv.Rows[e.RowIndex].
                        Cells[e.ColumnIndex].Value = PreValue;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please insert ONLY Numbers");
                    StopAction = true;
                    RationFormulationdgv.Rows[e.RowIndex].
                    Cells[e.ColumnIndex].Value = PreValue;
                }
            }
        }
        if (StopAction)
        {
            return;
        }
        try
        {
            RationFormulationDBConnection RFDBC = new
            RationFormulationDBConnection();
            RFDBC.UpdateFeedsDetails(RationFormulationdgv);
            RFDBC.SetFeedsIntoRationFormulationdgv
            (RationFormulationdgv, RationTotaldgv);
            RFDBC.SetRationTotaldgv(RationTotaldgv);
        }
        catch
        {
            MessageBox.Show("ErrorCellValueChangedEndCatch");
        }

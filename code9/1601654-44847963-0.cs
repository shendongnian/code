    private void MyInitializeComponent()
    {
        dg.CurrentCellDirtyStateChanged += Dg_CurrentCellDirtyStateChanged;
        dg.CellValueChanged += Dg_CellValueChanged;
        this.CalculateTotals();
    }
    private void Dg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dg.Columns[e.ColumnIndex].Name == "Choices")
        {
            switch (dg.Rows[e.RowIndex].Cells["Choices"].Value.ToString())
            {
                case ("Yes"):
                {
                    dg.Rows[e.RowIndex].Cells["PointsGained"].Value =
                        dg.Rows[dg.CurrentCell.RowIndex].Cells["PointsAvailable"].Value;
                    break;
                }
                case ("No"):
                {
                    dg.Rows[e.RowIndex].Cells["PointsGained"].Value = 0;
                    break;
                }
                case ("NA"):
                {
                    dg.Rows[e.RowIndex].Cells["PointsGained"].Value = "NA";
                    break;
                }
            }
    
            this.CalculateTotals();
        }
    }
    private void Dg_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if ((dg.Columns[dg.CurrentCell.ColumnIndex].Name == "Choices") &&
            (dg.IsCurrentCellDirty))
        {
            dg.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
    
    private void CalculateTotals()
    {
        var totalPointsGained = dg.Rows.Cast<DataGridViewRow>()
            .Where(a => a.Cells["PointsGained"].Value?.ToString() != "NA")
            .Sum(a => Convert.ToInt32(a.Cells["PointsGained"].Value));
    
        var totalPointsAvailable = dg.Rows.Cast<DataGridViewRow>()
            .Where(a => a.Cells["PointsAvailable"].Value?.ToString() != "NA")
            .Sum(a => Convert.ToInt32(a.Cells["PointsAvailable"].Value));
    
        lblTotalPointsGained.Text = "Total Points Gained: " + totalPointsGained;
        lblTotalAvailable.Text = "Total Points Available: " + totalPointsAvailable;
    }

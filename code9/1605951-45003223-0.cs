    // Search for the row index you want to display using LINQ
    var someRowIndex = dgNew.Rows.Cast<DataGridViewRow>()
        .FirstOrDefault(a => a.Cells["SomeColumnName"].Value != null &&
                             a.Cells["SomeColumnName"].Value == "Value of some column in the blue row")?.Index;
    
    if (someRowIndex != null)
    {
        dg.FirstDisplayedCell = dg.Rows[someRowIndex].Cells[0];
    }

    //Create new Numeric Column
    NumericColumn nCol = new NumericColumn();
    nCol.ReadOnly = false;
    nCol.Name = "MyColumnName";
    nCol.HeaderText = "My Numeric Column";
    nCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    nCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    
    //Assign it to your datagridview
    myDatagridview.Columns.Add(nCol);

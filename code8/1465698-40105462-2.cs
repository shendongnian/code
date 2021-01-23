    var table = new DataTable();
    table.Columns.AddRange(new[]
    {
        new DataColumn("preferred", typeof(string)),
        new DataColumn("checklist", typeof(int))
    });
    table.Rows.Add("Director Fury", 1);
    table.Rows.Add("Maria Hill", 0);
    gridControl1.DataSource = table;
    gridView1.PopulateColumns();
    var column = new GridColumn();
    column.FieldName = "cek22";
    column.UnboundType = UnboundColumnType.Boolean;
    column.UnboundExpression = "[checklist]";
    column.Visible = true;
    gridView1.Columns.Add(column);
    gridView1.CellValueChanging += (sender, e) =>
    {
        if (e.Column.FieldName == "cek22")
            gridView1.SetRowCellValue(e.RowHandle, "checklist", ((bool)e.Value) ? 1 : 0);
    };

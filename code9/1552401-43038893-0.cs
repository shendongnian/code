    Customers c61 = new Customers();
    c61.A = DateTime.Now.AddDays(1);
    Customers c62 = new Customers();
    c62.A = DateTime.Now.AddDays(3);
    List<Customers> tmpList = new List<Customers>();
    tmpList.Add(c61);
    tmpList.Add(c61);
    var view = gridControl1.MainView as GridView;
    view.OptionsBehavior.AutoPopulateColumns = false; // <= Turn off the autopulation before assign the data source.
    gridControl1.DataSource = tmpList;
    GridColumn gc = new GridColumn();
    view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gc });
    gc.Caption = "A";
    gc.FieldName = "A";
    gc.Visible = true; // <= Unhide your column.
    view.Columns["A"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
    view.Columns["A"].DisplayFormat.FormatString = "dd/MM/yyyy";

    var dt = new DataTable();
    dt.Columns.Add("A");
    dt.Columns.Add("B");
    dt.Rows.Add("1", "11");
    dt.Rows.Add("2", "22");
    dt.Rows.Add("3", "33");
    var dg = new DataGrid();
    dg.Dock = DockStyle.Fill;
    var ts = new DataGridTableStyle();
    ts.GridColumnStyles.Add(new MyDataGridTextBoxColumn() 
        { MappingName = "A", HeaderText = "A" });
    ts.GridColumnStyles.Add(new MyDataGridTextBoxColumn() 
        { MappingName = "B", HeaderText = "B" });
    dg.TableStyles.Add(ts);
    this.Controls.Add(dg);
    dg.DataSource = dt;
    dg.BringToFront();

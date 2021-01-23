    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("A");
        dt.Columns.Add("B");
        dt.Rows.Add("1", "11");
        dt.Rows.Add("2", "22");
        var dg = new DataGrid();
        dg.Dock = DockStyle.Fill;
        this.Controls.Add(dg);
        dg.BringToFront();
        dg.DataSource = dt;
        var ts = new DataGridTableStyle();
        ts.GridColumnStyles.Add(new MyDataGridTextBoxColumn() { MappingName = "A" });
        ts.GridColumnStyles.Add(new MyDataGridTextBoxColumn() { MappingName = "B" });
        dg.TableStyles.Add(ts);
        dg.DoubleClick += dg_DoubleClick;
    }
    void dg_DoubleClick(object sender, EventArgs e)
    {
        MessageBox.Show("DooubleClick!");
    }

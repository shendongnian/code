    private TabPage GetTabPageWithGrid(DataTable dt) {
      TabPage tp = new TabPage(dt.TableName.Replace("'", "").Replace("$", ""));
      tp.Controls.Add(GetDGV(dt));
      return tp;
    }
    private DataGridView GetDGV(DataTable dt) {
      return new DataGridView {
        Size = new Size(1000, 400),
        Name = "datagridView" + dt.TableName,
        DataSource = dt,
        ScrollBars = ScrollBars.Both
      };
    }

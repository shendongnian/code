    DataTable dt;
    public Form1() {
      InitializeComponent();
      dt = GetDataTable();
      dataGridView1.DataSource = dt;
      tbDate1.Text = "2/05/1957";
      tbDate2.Text = "3/22/1959";
    }
    private DataTable GetDataTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Col1");
      dt.Columns.Add("Col2");
      dt.Columns.Add("Date");
      dt.Rows.Add("R0C0", "R0C1", "3/22/1959");
      dt.Rows.Add("R1C0", "R1C1", "6/23/1936");
      dt.Rows.Add("R2C0", "R2C1", "3/22/1959");
      dt.Rows.Add("R3C0", "R3C1", "6/23/1936");
      dt.Rows.Add("R4C0", "R4C1", "3/22/1959");
      dt.Rows.Add("R5C0", "R5C1", "2/06/1957");
      dt.Rows.Add("R6C0", "R6C1", "2/05/1957");
      dt.Rows.Add("R1C0", "R1C1", "6/28/1936");
      return dt;
    }
    private void buttonFilter_Click(object sender, EventArgs e) {
      if (tbDate1.Text == "" || tbDate2.Text == "") {
        dt.DefaultView.RowFilter = "";
      }
      else {
        dt.DefaultView.RowFilter = string.Format("Date >='" + tbDate1.Text.Trim().Replace("'", "''") + "%' AND " +
                                                 "Date <= '" + tbDate2.Text.Trim().Replace("'", "''") + "%'");
      }
    }

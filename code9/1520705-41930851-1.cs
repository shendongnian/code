    DataTable dt;
    public Form1() {
      InitializeComponent();
      dt = GetDataTable();
      dataGridView1.DataSource = dt;
      tbDate1.Text = "2/05/1957";
      tbDate2.Text = "3/22/1959";
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

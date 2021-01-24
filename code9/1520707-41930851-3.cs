    DataTable dt;
    public Form1() {
      InitializeComponent();
      dt = GetYourDataTable();
      dataGridView1.DataSource = dt;
    }
    private void buttonFilter_Click(object sender, EventArgs e) {
      if (tbDate1.Text == "" || tbDate2.Text == "") {
        dt.DefaultView.RowFilter = "";
      }
      else {
        DateTime sDate;
        DateTime eDate;
        if ((DateTime.TryParse(tbDate1.Text, out sDate)) && (DateTime.TryParse(tbDate2.Text, out eDate))) {
          dt.DefaultView.RowFilter = string.Format("Date >= #" + sDate + "# AND Date <= #" + eDate + "#");
        }
      }
    }

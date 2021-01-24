    DataTable dt;
    string filePath = @"D:\Test\Artist.txt";
    char delimiter = ';';
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      dt = GetTableFromFile(filePath, delimiter);
      dataGridViewExistingAppntmntRecs.DataSource = dt;
      UpdateDataGridColors();
    }
    private DataTable GetTableFromFile(string filePath, char delimiter) {
      List<string[]> allArtists = GetArtistList(filePath, delimiter);
      DataTable dt = GetTableColumns(allArtists[0]);
      int totalCols = dt.Columns.Count;
      DataRow dr;
      for (int i = 1; i < allArtists.Count; i++) {
        string[] curArtist = allArtists[i];
        dr = dt.NewRow();
        for (int j = 0; j < totalCols; j++) {
          dr[j] = curArtist[j].ToString();
        }
        dt.Rows.Add(dr);
      }
      return dt;
    }
    private List<string[]> GetArtistList(string inFilePath, char inDelimiter) {
      string pathToFile = inFilePath;
      char delimiter = inDelimiter;
      List<string[]> listStringArrays = File.ReadAllLines(pathToFile).Select(x => x.Split(delimiter)).ToList();
      return listStringArrays;
    }
    private DataTable GetTableColumns(string[] allHeaders) {
      DataTable dt = new DataTable();
      foreach (string curHeader in allHeaders) {
        dt.Columns.Add(curHeader, typeof(string));
      }
      return dt;
    }
    private Color GetColorForRow(DataRowView dr) {
      // paint it black ;-)
      if (dr[0].ToString().Equals("Rolling Stones")) {
        return Color.Black;
      }
      DateTime rowDate;
      DateTime dateNow = DateTime.Now;
      DateTime twoMonthsLimit = dateNow.AddMonths(2);
      DateTime oneMonthLimit = dateNow.AddMonths(1);
      if (dr != null) {
        string rowStringMonth = dr[17].ToString();
        string rowStringYear = dr[18].ToString();
        string rowStringDate = "1/" + rowStringMonth + "/" + rowStringYear;
        if (DateTime.TryParse(rowStringDate, out rowDate)) {
          if (rowDate > twoMonthsLimit)
            return Color.White;
          if (rowDate > oneMonthLimit)
            return Color.Yellow;
          if (rowDate > dateNow)
            return Color.Orange;
          if (rowDate.Month == dateNow.Month)
            return Color.Orange;
          // this row date is less than todays month date
          return Color.Red;
        } // else date time parse unsuccessful - ignoring
      }
      // date is null
      return Color.White;
    }
    private void UpdateDataGridColors() {
      Color rowColor;
      DataRowView dr;
      foreach (DataGridViewRow dgvr in dataGridViewExistingAppntmntRecs.Rows) {
        dr = dgvr.DataBoundItem as DataRowView;
        if (dr != null) {
          rowColor = GetColorForRow(dr);
          dgvr.DefaultCellStyle.BackColor = rowColor;
          if (rowColor == Color.Black)
            dgvr.DefaultCellStyle.ForeColor = Color.White;
        }
      }
    }
    private void dataGridViewExistingAppntmntRecs_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 17 || e.ColumnIndex == 18) {
        //MessageBox.Show("End Date Changed");
        UpdateDataGridColors();
      }
    }
    private void dataGridViewExistingAppntmntRecs_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
      UpdateDataGridColors();
    }

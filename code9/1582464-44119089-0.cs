    Prime PrimeObject;
 
    private void btnReadJson_Click(object sender, EventArgs e) {
      try {
        string json = File.ReadAllText(jsonFile);
        PrimeObject = JsonConvert.DeserializeObject<Prime>(json);
        dgvRamps.DataSource = PrimeObject.ramps;
        lblColorGroup.Text = "Prime name: " + PrimeObject.name + " - Response Code: " + PrimeObject.response_code;
      }
      catch (Exception ex) {
        MessageBox.Show("Error reading JSON file: " + jsonFile + Environment.NewLine + ex.Message);
      }
    }
    private void dgvColor_SelectionChanged(object sender, EventArgs e) {
      try {
        if (dgvRamps.SelectedCells.Count > 0) {
          int colorIndex = dgvRamps.SelectedCells[0].RowIndex;
          dgvPoints.DataSource = PrimeObject.ramps[colorIndex].points;
        }
      }
      catch (Exception ex) {
        MessageBox.Show("SelectionChanged: Error: " + ex.Message);
      }
    }

    private void button2_Click(object sender, EventArgs e) {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "txt files (*.txt)|*.txt|Csv files (*.csv)|*.csv";
      sfd.FilterIndex = 2;
      if (sfd.ShowDialog() == DialogResult.OK) {
        try {
          using (StreamWriter sw = new StreamWriter(sfd.FileName, false)) {
            string columnString = "";
            for (int i = 0; i < dt.Columns.Count - 1; i++) {
              columnString += dt.Columns[i].ColumnName;
              if (i < dataGridView1.Columns.Count - 2)
                columnString += ",";
            }
            sw.WriteLine(columnString);
            string rowString = "";
            foreach (DataRow dr in dt.Rows) {
              rowString = "";
              for (int i = 0; i < dt.Columns.Count - 1; i++) {
                rowString += dr.ItemArray[i].ToString();
                if (i < dt.Columns.Count - 2)
                  rowString += ",";
              }
              sw.WriteLine(rowString);
            }
          }
        }
        catch (Exception exceptionObject) {
          MessageBox.Show(exceptionObject.ToString());
        }
      }
    }

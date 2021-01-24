     string bigString = File.ReadAllText(ofd.FileName);
      try {
        using (StreamWriter sw = new StreamWriter(ofd.FileName + ".output")) {
          for (int k = 0; k < dgvMapping.Rows.Count; k++) {
            if (dgvMapping.Rows[k].Cells[0].Value != null && dgvMapping.Rows[k].Cells[1].Value != null) {
              string searchTerm = dgvMapping.Rows[k].Cells[0].Value.ToString();
              string replaceTerm = dgvMapping.Rows[k].Cells[1].Value.ToString();
              if (searchTerm != "") {
                bigString = bigString.Replace(searchTerm, replaceTerm);
              } else {
                // one of the terms is empty
              }
            } else {
              // one of the terms is null}
            }
          }
          sw.WriteLine(bigString);
        }
      }
      catch (Exception ex) {
        MessageBox.Show("Write Erro: " + ex.Message);
      }

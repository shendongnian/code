    using (StreamWriter sw = new StreamWriter(ofd.FileName + ".output")) {
      for (int i = 0; i < arrayofLine.Length; i++) {
        string line = arrayofLine[i];
        for (int k = 0; k < dgvMapping.Rows.Count; k++) {
          if (dgvMapping.Rows[k].Cells[0].Value != null && dgvMapping.Rows[k].Cells[1].Value != null) {
            string searchTerm = dgvMapping.Rows[k].Cells[0].Value.ToString();
            string replaceTerm = dgvMapping.Rows[k].Cells[1].Value.ToString();
            if (searchTerm != "" && replaceTerm != "") {
              line = line.Replace(searchTerm, replaceTerm);
            }
            else
            {
              // one of the terms is empty
            }
          }
          else
          {
            // one of the terms is null}
          }
        }
        sw.WriteLine(line);
      }
    }

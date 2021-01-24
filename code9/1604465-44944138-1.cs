    private void button1_Click(object sender, EventArgs e) {
      if (openFile.ShowDialog() == DialogResult.OK) {
        List<string[]> rows = File.ReadLines(openFile.FileName).Select(x => x.Split(',')).ToList();
        List<string> headerNames = rows[0].ToList();
        foreach (var headers in rows[0]) {
          dt.Columns.Add(headers);
        }
        foreach (var x in rows.Skip(1).OrderBy(r => r.First())) {
          if ((!(x[0] == "Lot ID")) || (!(x.All(val => string.IsNullOrWhiteSpace(val)))))
            dt.Rows.Add(x);
        }
        dataGridView1.DataSource = dt;
        dataGridView1.ReadOnly = true;
      }
    }

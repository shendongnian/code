    try {
      using (var fs = File.OpenRead(Dialog.FileName)) {
        using (var reader = new StreamReader(fs)) {
          List<string> lista = new List<string>();
          List<string> listb = new List<string>();
          string temp;
          while (!reader.EndOfStream) {
            var line = reader.ReadLine();
            var values = line.Split(',');
            lista.Add(values[0]);
            GetLuhnCheckDigit(values[0]); // <-- What is this method doing??? 
            listb.Add(last.ToString());
            temp = values[0] + last.ToString();
            dt1.Rows.Add(values[0], temp); // <-- this adds both columns
          }
          dataGridView1.DataSource = dt1;
        }
      }
    }
    catch (Exception e) {
      MessageBox.Show("Error: " + e.Message);
    }

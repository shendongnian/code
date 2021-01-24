    private void btnAdd_Click(object sender, EventArgs e) {
      var xSuccess = int.TryParse(txtIn1.Text, out int x);
      var ySuccess = int.TryParse(txtIn2.Text, out int y);
      if(!xSuccess)
        MessageBox.Show($"{x} could not be parsed to int!");
      if(!ySuccess)
        MessageBox.Show($"{y} could not be parsed to int!");
      if(xSuccess && ySuccess)
        lstOut.Items.Add((x + y).ToString("N0"));
    }

    private void btnAdd_Click(object sender, EventArgs e) {
        try {
          int x = int.Parse(txtIn1.Text);
          int y = int.Parse(txtIn2.Text);
          txtIn1.Text = x.ToString();
          txtIn2.Text = y.ToString();
          lstOut.Items.Add((x + y).ToString("N0"));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
    }

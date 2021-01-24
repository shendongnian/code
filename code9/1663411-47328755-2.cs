    private string keysTyped = string.Empty;
    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
      KeysConverter conv = new KeysConverter();
      this.keysTyped+=conv.ConvertToString(e.KeyCode).Replace("NumPad", "");
      int numTyped;
      while (int.TryParse(this.keysTyped, out numTyped))
      {
        if (numTyped <= 12)
        {
          this.comboBox1.SelectedIndex = numTyped - 1;
          break;
        }
        this.keysTyped = this.keysTyped.Substring(1);
      }
    }

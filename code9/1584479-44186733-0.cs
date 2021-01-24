    private bool cbLock = false;
    private void comboBox1_TextChanged(object sender, EventArgs e)
    {
      // lock is required, as this event also will occur when changing the selected index
      if (cbLock)
        return;
      cbLock = true;
      int i = comboBox1.SelectionStart;
      // store the typed string before changing DS
      string text = comboBox1.Text.Substring(0, i);
      List<string> ds = new System.Collections.Generic.List<string>() { "aaaaaa", "aaabbb", "aaacccc" };
      comboBox1.DataSource = ds;
      // select first match manually
      for (int index = 0; index < ds.Count; index++)
      {
        string s = ds[index];
        if (s.StartsWith(text))
        {
          comboBox1.SelectedIndex = index;
          break;
        }
      }
      // restore cursor position and free the lock
      comboBox1.SelectionStart = i;
      cbLock = false;
    }

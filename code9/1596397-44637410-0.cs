    Control lastControl = null;
    if (listPoint.Contains('^')) {
      var listTextboxes = listPoint.Split('^');
      int textBoxCount = listTextboxes.Count();
      int index = 1;
      foreach (var listTextbox in listTextboxes) {
        CheckBox ck = new CheckBox();
        ck.Text = listTextbox;
        ck.AutoSize = true;
        ck.CheckStateChanged += new EventHandler(this.CheckBox_CheckedChanged);
        flowLayoutPanel1.Controls.Add(ck);
        if (index < textBoxCount) {
          TextBox tb = new TextBox();
          tb.AutoSize = true;
          tb.TextChanged += new EventHandler(this.TextBox_TextChanged);
          flowLayoutPanel1.Controls.Add(tb);
          lastControl = tb;
        } else {
          lastControl = ck;
        }
        index++;
      }
      if (lastControl != null) {
        flowLayoutPanel1.SetFlowBreak(lastControl, true);
      }

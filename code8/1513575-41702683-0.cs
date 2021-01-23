    List<string> comboData;
    public Form1() {
      InitializeComponent();
      comboData = new List<string>();
      for (int i = 1; i < 100; i++) {
        comboData.Add(i.ToString());
      }
      comboBox1.DataSource = comboData;
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      MessageBox.Show("selection changed  " + comboBox1.Text);
    }
    private void comboBox1_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        if (comboData.Contains(comboBox1.Text.ToString())) {
          MessageBox.Show("User entered existing data: " + comboBox1.Text);
          // selection changed event has already handled this, however
          // if the user just pressed "enter" previously
          // then selection changed event wont get fired because the selection did not change
        }
        else {
          MessageBox.Show("User entered NEW data: " + comboBox1.Text);
          // we have data that is NOT currently in the list
          // so selection changed WONT get fired
          // need to call your method with user typed value
        }
      }
    }
    // make user user only enters numbers
    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) {
      if (!Char.IsNumber(e.KeyChar)) {
        e.Handled = true;
      }
    }

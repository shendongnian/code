    private void listBox1_DoubleClick(object sender, EventArgs e) {
      int selectedIndex = listBox1.SelectedIndex;
      if (selectedIndex >= 0) {
        listBox1.Items.RemoveAt(selectedIndex);
        txtTotal.Text = GetTotal().ToString();
      }
    }

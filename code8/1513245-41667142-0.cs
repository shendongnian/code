    private void button1_Click(object sender, EventArgs e) {
      // Make a list of the checked colors you want to pass
      //List<string> checkedItems = new List<string>();
      int index;
      foreach (string item in checkedListBox1.Items) {
        index = checkedListBox1.Items.IndexOf(item);
        string checkState = checkedListBox1.GetItemCheckState(index).ToString(); 
        MessageBox.Show("Item on line " + index + " name: " + item +
                        " is currently: " + checkState);
      }
    }

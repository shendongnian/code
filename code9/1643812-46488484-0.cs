    private void button3_Click(object sender, EventArgs e){
        string s = "    Search Via Forename";
        int result = 0;
        int count = 0;
        result = string.Compare(textBox1.Text, s);
        switch ((result == 0) || (String.IsNullOrEmpty(textBox1.Text))){
            case true: MessageBox.Show("Please input forename...");
                       break;
              default: foreach (ListViewItem item in listView1.Items){
                             item.Selected = false;
                          if (item.Text.ToLower().StartsWith(textBox1.Text.ToLower())){                             
                             item.BackColor = Color.CornflowerBlue;
                             item.ForeColor = Color.White;
                             count++;
                          }else{
                             item.BackColor = Color.White;
                             item.ForeColor = Color.Black;
                          }
                       }
                       if (listView1.SelectedItems.Count == 1){
                           listView1.Focus();
                       }
                       textBox1.Text = "    Search Via Forename";
                       textBox1.ForeColor = Color.Silver;
                       break;
        }
    }

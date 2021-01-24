    public void AddNewItemToListBox(string text)
    {
      // Make existing background white      
      for (int i = 0; i <= listView1.Items.Count - 1; i++)
      {
        listView1.Items[i].BackColor = Color.White;
      }
      // New one with red background
      ListViewItem lvi = new ListViewItem(); 
      lvi.Text = text;
      lvi.BackColor = Color.Red;
      lv.Items.Add(lvi); // lv is your listview
    }

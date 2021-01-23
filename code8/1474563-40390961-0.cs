            private void button4_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
            for (int  i = listView1.Items.Count -1; i >= 0; i--)
            {
                if (listView1.Items[i].ToString().ToLower().Contains(searchBox.Text.ToLower())) {
                    listView1.Items[i].Selected = true;
                }
            }
      
        

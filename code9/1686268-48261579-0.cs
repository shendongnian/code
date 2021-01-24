    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(listView1.SelectedItems.Count == 0) return;
      for(int i=0;i<=listView1.SelectedItems.Count-1;i++)
      {
          string filepath = Path.GetDirectoryName(listView1.SelectedItems[i].Text);
          listBox1.Items.Add(filepath);
      }
    }
 

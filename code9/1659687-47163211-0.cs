    foreach (ListViewItem item in listView1.Items){
        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems){
                  ---- use subItem here        
                  |
                  v
            if (subItem.Text.ToLower().StartsWith(textBox1.Text.ToLower())){
                count++;
                statusBar1.Panels[2].Text = "Found: " + count.ToString();
            }else{
                listView1.Items.Remove(item);
            }
        }
    }

            listView1.Items newItemList = new listView1.Items();
            foreach (ListViewItem item in listView1.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().StartsWith(textBox1.Text.ToLower()))
                    {
                        var index = item.Index;
                        MessageBox.Show(listView1.Items[index].ToString());
                        count++;
                        newItemList.Add(item); 
                        
                    }
                    else
                    {
                        //listView1.Items[item].Remove(); 
                    }
                }
            }

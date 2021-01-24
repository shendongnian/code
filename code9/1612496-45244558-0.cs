    private void button1_Click(object sender, EventArgs e)
            {
                foreach (ListViewItem Item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(Item);
                }
            }  

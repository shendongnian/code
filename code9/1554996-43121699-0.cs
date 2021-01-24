     private void btnadd_Click(object sender, EventArgs e)
     {
         ListViewItem data = new ListViewItem();
         data.Text = (listView1.Items.Count + 1).ToString();
         data.SubItems.Add(txtname.Text);
         data.SubItems.Add(txtsur.Text);
         data.SubItems.Add(txtage.Text);
         listView1.Items.Add(data);
         clear();
     }

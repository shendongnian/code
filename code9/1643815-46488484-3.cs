    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
            }
        }

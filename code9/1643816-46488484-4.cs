    private void button3_Click(object sender, EventArgs e)
        {
            string s = "    Search Via Forename";
            int result = 0;
            int count = 0;
            result = string.Compare(textBox1.Text, s);
            // Do the check on the input
            if ((result == 0) || (string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Please input forename...");
                // after notifying the user just return
                return;
            }
            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = false;
                if (item.Text.ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    item.BackColor = Color.CornflowerBlue;
                    item.ForeColor = Color.White;
                    count++;
                }
                else
                {
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                }
            }
            if (listView1.SelectedItems.Count == 1)
            {
                listView1.Focus();
            }
        }

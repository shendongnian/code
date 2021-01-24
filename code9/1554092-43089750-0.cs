        ListViewItem lvi;
        private void button1_Click(object sender, EventArgs e)
        {
            lvi  = new ListViewItem();
            string time = DateTime.Now.ToString("HH:mm");
            lvi.Text = time;
            listView1.Items.Add(lvi);
        }

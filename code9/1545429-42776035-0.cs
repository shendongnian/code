        private void colorReady()
        {
            foreach (ListViewItem li in listView1.Items)
            {
                if(li.Text=="Ready") {
                    li.BackColor = Color.Red;
                }
            }
        }

        private void colorReady()
        {
            foreach (ListViewItem li in listView1.Items)
            {
                if(li.Text == "Ready")
                {
                    li.SubItems.Add("Color");
                    li.SubItems[0].ForeColor = Color.Red;
                    li.UseItemStyleForSubItems = false;
                }
            }
        }

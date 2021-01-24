        DateTime lastClickDate = DateTime.Now;
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //You can change the value 1200 as you want.
            if ((DateTime.Now - lastClickDate).TotalMilliseconds < 1200)
            {
                MessageBox.Show("double clicked");
            }
            this.Text = (DateTime.Now - lastClickDate).TotalMilliseconds.ToString();
            lastClickDate = DateTime.Now;
        }

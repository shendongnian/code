     private void listView1_MouseUp(object sender, MouseEventArgs e)
            {
                ListView tmp_SenderListView = sender as ListView;
                if (e.Button == MouseButtons.Right)
                {
    
                    if (tmp_SenderListView.SelectedItems.Count > 0)
                    {
                        contextMenuStrip1.Show(tmp_SenderListView, e.Location);
                    }
                    else
                    {
                        contextMenuStrip2.Show(tmp_SenderListView, e.Location);
                    }
                }
            }

    private void ItemMouseDown(object sender, MouseEventArgs e)
    {
         if(e.Button == MouseButtons.Right)
         {
              ListViewItem item = listView.GetItemAt(e.X, e.Y);
              if(item != null)
              {
                 // here we have
              }
         }
    }

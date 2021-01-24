        private void txtbx_text1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            ContextMenu cm = new ContextMenu();//make a context menu instance
            MenuItem item = new MenuItem();//make a menuitem instance
            item.Text = "remove all";//give the item a header
            item.Click += DoNothing;//give the item a click event handler
            cm.MenuItems.Add(item);//add the item to the context menu
            item = new MenuItem();//recycle the menu item
            item.Text = "load from file";//give the item a header
            item.Click += DoNothing;//give the item a click event handler
            cm.MenuItems.Add(item);//add the item to the context menu
            item = new MenuItem();//recycle item into a new menuitem
            item.Text = "save list";//give the item a header
            item.Click += DoNothing;//give the item a click event handler
            cm.MenuItems.Add(item);//add the item to the context menu
            ((RichTextBox)sender).ContextMenu = cm;//add the context menu to the sender
            cm.Show(txtbx_text1, Cursor.Position);//show the context menu
        }
        private void DoNothing(object sender, EventArgs e)
        {
            //doing nothing
            return;
        }

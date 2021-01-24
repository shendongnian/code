        private void txtbx_text1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            ContextMenu cm = new ContextMenu();//make a context menu instance
            MenuItem item = new MenuItem();//make a menuitem instance
            item.Text = "remove line";//give the item a header
            item.Click += (sendingelement, eventargs) => RemoveLine(sender, e);//give the item a click event handler
            cm.MenuItems.Add(item);//add the item to the context menu
            ((RichTextBox)sender).ContextMenu = cm;//add the context menu to the sender
            cm.Show(txtbx_text1, e.Location);//show the context menu
        }
        private void RemoveLine(object sender, MouseEventArgs e)
        {
            int charNextToCursor = txtbx_text1.GetCharIndexFromPosition(e.Location);
            int lineNumFromChar = txtbx_text1.GetLineFromCharIndex(charNextToCursor);
            int firstCharOfLine = txtbx_text1.GetFirstCharIndexFromLine(lineNumFromChar);
            int lineLength = txtbx_text1.Lines[lineNumFromChar].Length;
            string firstchar = txtbx_text1.Text.Substring(firstCharOfLine, 1);
            txtbx_text1.Text = txtbx_text1.Text.Remove(firstCharOfLine, lineLength).ToString();
            return;
        }

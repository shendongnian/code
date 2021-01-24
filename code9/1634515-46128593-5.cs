        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            int idx = 0;
            if (e.SubItem.Tag != null) idx = (int)e.SubItem.Tag;
            Bitmap bmp = (Bitmap)listView1.SmallImageList.Images[idx];
            Rectangle rTgt = new Rectangle(e.Bounds.Location, 
                                           listView1.SmallImageList.ImageSize);
            // optionally show selection:
            if (e.ItemState.HasFlag(ListViewItemStates.Selected))
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
            if (bmp != null) e.Graphics.DrawImage(bmp, rTgt);
            // optionally draw text
            e.Graphics.DrawString(e.SubItem.Text, listView3.Font, Brushes.Black,
                   e.Bounds.X + listView3.SmallImageList.ImageSize.Width + 2, e.Bounds.Y + 2);
        }

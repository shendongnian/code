        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            Size sz = listView1.SmallImageList.ImageSize;
            int idx = 0;
            if (e.SubItem.Tag != null) idx = (int)e.SubItem.Tag;
            Bitmap bmp = (Bitmap)listView1.SmallImageList.Images[idx];
            Rectangle rTgt = new Rectangle(e.Bounds.Location, sz);
            bool selected = e.ItemState.HasFlag(ListViewItemStates.Selected);
            // optionally show selection:
            if (selected ) e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
            if (bmp != null) e.Graphics.DrawImage(bmp, rTgt);
            // optionally draw text
            e.Graphics.DrawString(e.SubItem.Text, listView1.Font,
                                  selected  ? Brushes.White: Brushes.Black,
                                  e.Bounds.X + sz.Width + 2, e.Bounds.Y + 2);
        }

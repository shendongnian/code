        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            int idx = 0;
            if (e.SubItem.Tag != null) idx = (int)e.SubItem.Tag;
            Bitmap bmp = (Bitmap)listView1.SmallImageList.Images[idx];
            Rectangle rTgt = new Rectangle(e.Bounds.Location, 
                                           listView1.SmallImageList.ImageSize);
            if (bmp != null) e.Graphics.DrawImage(bmp, rTgt);
        }

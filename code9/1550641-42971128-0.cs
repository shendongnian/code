        ToolTip mTooltip;
        Point mLastPos = new Point(-1, -1);
        ListViewHitTestInfo info;
        ListViewItem.ListViewSubItem lastSubItem;
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            info = listView1.HitTest(e.X, e.Y);
            if (mTooltip == null)
                mTooltip = new ToolTip();
            if (mLastPos != e.Location)
            {
                if (info.Item != null && info.SubItem != null)
                {
                    if (info.SubItem != lastSubItem)
                    {
                        mTooltip.ToolTipTitle = info.Item.Text;
                        mTooltip.Show(info.SubItem.Text, info.Item.ListView, e.X, e.Y, 20000);
                        lastSubItem = info.SubItem;
                    }
                }
                else
                {
                    mTooltip.SetToolTip(listView1, string.Empty);
                }
            }
            mLastPos = e.Location;
        }

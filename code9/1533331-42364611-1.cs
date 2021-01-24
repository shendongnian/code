    Point eLoc = listView1.PointToClient(Control.MousePosition);
    ListViewHitTestInfo hit = null;
    int i = 0;
    do
    {
        Point vp = new Point(eLoc.X, listView1.Items[i].Bounds.Top);
        hit = listView1.HitTest(vp);
        i++;
    }
    while( hit.SubItem == null && i < listView1.Items.Count);
    var ColumnIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

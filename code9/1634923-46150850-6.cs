    private void listView1_DragOver(object sender, DragEventArgs e)
    {
        Point mLoc = listView1.PointToClient(Cursor.Position);
        var hitt = listView1.HitTest(mLoc);
        if (hitt.Item == null) return;
        int idx = hitt.Item.Index;
        if (idx == prevItem) return;
        listView2.Refresh();
        using (Graphics g = listView1.CreateGraphics())
        {
            Rectangle rect = listView1.GetItemRect(idx);
            g.DrawLine(Pens.Red, rect.Left, rect.Top, rect.Right, rect.Top);
        }
    }

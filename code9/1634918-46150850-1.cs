    private void listBox1_DragOver(object sender, DragEventArgs e)
    {
        Point mLoc = listBox1.PointToClient(Cursor.Position);
        int idx = listBox1.IndexFromPoint(mLoc);
        if (idx  < 0) return;
        listBox1.Refresh();
        using (Graphics g = listBox1.CreateGraphics())
        {
            Rectangle rect = listBox1.GetItemRectangle(idx);
            g.DrawLine(Pens.Red, rect.Left, rect.Top, rect.Right, rect.Top);
        }
    }

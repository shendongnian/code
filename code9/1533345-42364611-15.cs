    void getHeaders(ListView lv)
    {
        lvHeaderBounds.Clear();
        for (int i = 0; i < lv.Columns.Count; i++)
        {
            ColumnHeader ch = lv.Columns[i];
            int left = i == 0 ? 0 : lvHeaderBounds[i-1].X + ch.Width;
            Rectangle r = new Rectangle(left, 0, ch.Width, 0);
            lvHeaderBounds.Add(r);
        }
    }

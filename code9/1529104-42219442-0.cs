    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0201 && m.WParam.ToInt32() == 0x0001)
        {
            var target = (Control as MyTabControl);
            if (true) //how to know if focused?
            {
                var lparam32 = m.LParam.ToInt32();
                int lowWord = lparam32 & 0xffff;
                int highWord = lparam32 >> 16;
                Point p = new Point(lowWord, highWord);
                if (target.IsHeaderArea(p))
                {
                    target.DesignTimeClick(MouseButtons.Left, p);
                }
            }
        }
        base.WndProc(ref m);
    }
